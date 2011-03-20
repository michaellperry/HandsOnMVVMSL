using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace HandsOnMVVMSL.Utilities
{
    public class MappedObservableCollection<TSource, TTarget>
    {
        private Func<TSource, TTarget> _map;
        private ObservableCollection<TSource> _sourceCollection;
        private ObservableCollection<TTarget> _targetCollection = new ObservableCollection<TTarget>();

        public MappedObservableCollection(Func<TSource, TTarget> map, ObservableCollection<TSource> sourceCollection)
        {
            _map = map;
            _sourceCollection = sourceCollection;

            _sourceCollection.CollectionChanged += SourceCollectionChanged;
        }

        public ObservableCollection<TTarget> TargetCollection
        {
            get { return _targetCollection; }
        }

        private void SourceCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                // Add the corresponding targets.
                int index = e.NewStartingIndex;
                foreach (TSource item in e.NewItems)
                {
                    _targetCollection.Insert(index, _map(item));
                    ++index;
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                // Delete the corresponding targets.
                for (int i = 0; i < e.OldItems.Count; i++)
                {
                    _targetCollection.RemoveAt(e.OldStartingIndex);
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Replace)
            {
                // Replace the corresponding targets.
                for (int i = 0; i < e.OldItems.Count; i++)
                {
                    _targetCollection[i + e.OldStartingIndex] = _map((TSource)e.NewItems[i + e.NewStartingIndex]);
                }
            }
            else
            {
                // Just give up and start over.
                _targetCollection.Clear();
                PopulateTargetCollection();
            }
        }

        private void PopulateTargetCollection()
        {
            foreach (TSource item in _sourceCollection)
            {
                _targetCollection.Add(_map(item));
            }
        }
    }
}
