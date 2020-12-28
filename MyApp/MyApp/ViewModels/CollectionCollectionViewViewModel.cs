using ReactiveUI;
using DynamicData;
using System.Collections.ObjectModel;
using System;
using System.Reactive;
using System.Reactive.Linq;

namespace MyApp.ViewModels
{
    public class CollectionCollectionViewViewModel : ReactiveObject
    {
        public CollectionCollectionViewViewModel()
        {
            _people.Connect().Bind(out _peopleWrapper).Subscribe();
            EditPerson = ReactiveCommand.Create<string, Unit>((s) =>
            {
                EditingID = s;
                return Unit.Default;
            });
            _showEditingID = this.WhenAnyValue(vm => vm.EditingID)
                .Select(id => id != null)
                .ToProperty(this, nameof(ShowEditingID));
            _editingPerson = this.WhenAnyValue(vm => vm.EditingID)
                .Select(id => id == null
                ? null
                : _people.Lookup(id).HasValue ? _people.Lookup(id).Value : null)
                .Catch<PersonModel,Exception>((e) => {
                    return null;
                })
                .ToProperty(this, nameof(EditingPerson));
            AddNewPerson = ReactiveCommand.Create(() =>
            {
                var id = Guid.NewGuid().ToString();
                _people.AddOrUpdate(new PersonModel
                {
                    ID = id,
                    Name = "new name"
                });
                EditingID = id;
            });

            DeletePerson = ReactiveCommand.Create<string, Unit>((id) =>
            {
                _people.RemoveKey(id);
                return Unit.Default;
            });
        }

        private readonly SourceCache<PersonModel, string> _people = new SourceCache<PersonModel, string>(m => m.ID);

        private readonly ReadOnlyObservableCollection<PersonModel> _peopleWrapper;
        public ReadOnlyObservableCollection<PersonModel> People => _peopleWrapper;

        public ReactiveCommand<string, Unit> EditPerson { get; }

        private string _editingID;
        public string EditingID
        {
            get => _editingID;
            set => this.RaiseAndSetIfChanged(ref _editingID, value);
        }

        private readonly ObservableAsPropertyHelper<bool> _showEditingID;
        public bool ShowEditingID => _showEditingID.Value;

        private readonly ObservableAsPropertyHelper<PersonModel> _editingPerson;
        public PersonModel EditingPerson => _editingPerson.Value;

        public ReactiveCommand<Unit,Unit> AddNewPerson { get; }

        public ReactiveCommand<string,Unit> DeletePerson { get; }
    }
}
