using ReactiveUI;
using DynamicData;
using System.Collections.ObjectModel;
using System;

namespace MyApp.ViewModels
{
    public class CollectionCollectionViewViewModel : ReactiveObject
    {
        public CollectionCollectionViewViewModel()
        {
            _people.Connect().Bind(out _peopleWrapper).Subscribe();
        }

        private readonly SourceCache<PersonModel, string> _people = new SourceCache<PersonModel, string>(m => m.Name);

        private readonly ReadOnlyObservableCollection<PersonModel> _peopleWrapper;
        public ReadOnlyObservableCollection<PersonModel> People => _peopleWrapper;

        public void AddOrUpdatePerson(string name,double age)
        {
            _people.AddOrUpdate(new PersonModel
            {
                Name = name,
                Age = age
            });
        }

        public void AddAge(string name,double amount)
        {
            var found = _people.Lookup(name);
            if (!found.HasValue) return;
            found.Value.Age += amount;
        }
    }
}
