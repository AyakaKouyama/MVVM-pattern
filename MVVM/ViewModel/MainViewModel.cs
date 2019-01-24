using MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadanie3;

namespace MVVM.ViewModel
{

    public class MainViewModel : ViewModelBase
    {

        #region Private Fields

        private Employees employees;
        private ObservableCollection<Employee> list;
        private ObservableCollection<Person> names;
        private Employee currentEmployee;
        private Person currentPerson;
        private bool visibitiy;
        private bool enabledButton;
        private bool saveVisibility;
        private SaveButton saveButton;
        private ModifyButton modifyButton;
        private RemoveButton removeButton;
        private AddButton addButton;
        private LoadButton loadButton;

        #endregion

        #region Properties

        public IShowPopUp PopUp { get; set; }


        public RealyCommand Load
        {
            get
            {
                return loadButton.Load;
            }
            set
            {
                loadButton.Load = value;
            }
        }
        public RealyCommand Add
        {
            get
            {
                return addButton.Add;
            }
            set
            {
                addButton.Add = value;
            }
        }
        public RealyCommand Remove
        {
            get
            {
                return removeButton.Remove;
            }
            set
            {
                removeButton.Remove = value;
            }
        }

        public RealyCommand Modify
        {
            get
            {
                return modifyButton.Modify;
            }
            set
            {
                modifyButton.Modify = value;
            }
        }
        public RealyCommand Save
        {
            get
            {
                return saveButton.Save;
            }
            set
            {
                saveButton.Save = value;
            }
        }

        public bool EnabledButton
        {
            get
            {
                return enabledButton;
            }
            set
            {
                enabledButton = value;
                RaisePropertyChanged();
            }
        }

        public bool SaveVisibility
        {
            get
            {
                return saveVisibility;
            }
            set
            {
                saveVisibility = value;
                RaisePropertyChanged();
            }
        }

        public int Details
        {
            get
            {
                return currentEmployee.BusinessEntityID;
            }
            set
            {
                RaisePropertyChanged();
            }
        }

        public Person CurrentPerson
        {
            get
            {
                return currentPerson;
            }
            set
            {
                currentPerson = value;
                if (currentPerson != null)
                {
                    try
                    {
                        Employee emp = list.Single(i => currentPerson.BusinessEntityID == i.BusinessEntityID);
                        CurrentEmployee = emp;
                        RaisePropertyChanged();
                    }
                    catch (Exception exc)
                    {
                        CurrentEmployee = null;
                        RaisePropertyChanged();
                    }

                    SaveVisibility = false;
                }

            }

        }

        public Employee CurrentEmployee
        {
            get
            {
                return currentEmployee;
            }
            set
            {
                try
                {
                    currentEmployee = value;
                    RaisePropertyChanged();
                }
                catch (Exception exc)
                {
                    PopUp.Show(exc.Message, 1);
                }
            }
        }

        public ObservableCollection<Employee> List
        {
            get
            {
                return list;
            }
            set
            {
                list = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<Person> Names
        {
            get
            {
                return names;
            }
            set
            {
                names = value;
                RaisePropertyChanged();
            }
        }

        public Employees Employees
        {
            get
            {
                return employees;
            }
            set
            {
                employees = value;

                try
                {
                    List = new ObservableCollection<Employee>(employees.Employee);
                    Names = new ObservableCollection<Person>(employees.Person);
                    Visibitity = true;
                    EnabledButton = true;
                    RaisePropertyChanged();
                }
                catch(Exception exc)
                {
                    PopUp.Show(exc.Message, 1);
                }
            }
        }

        public bool Visibitity
        {
            get
            {
                return visibitiy;
            }
            set
            {
                visibitiy = value;
                RaisePropertyChanged();
            }
        }

        #endregion Properties

        #region Contructors
        public MainViewModel()
        {
            Visibitity = false;
            EnabledButton = false;
            SaveVisibility = false;        
            this.PopUp = new PopUpWindow();
            this.loadButton = new LoadButton(this);
            this.addButton = new AddButton(this);
            this.removeButton = new RemoveButton(this);
            this.saveButton = new SaveButton(this);
            this.modifyButton = new ModifyButton(this);
        }


        public MainViewModel(IShowPopUp popUp)
        {
            Visibitity = false;
            EnabledButton = false;
            SaveVisibility = false;
            this.PopUp = popUp;
            this.loadButton = new LoadButton(this);
            this.addButton = new AddButton(this);
            this.removeButton = new RemoveButton(this);
            this.saveButton = new SaveButton(this);
            this.modifyButton = new ModifyButton(this);
        }

        #endregion

        #region Methods
        public void ResetValues()
        {
            CurrentPerson = null;
            CurrentEmployee = null;
            CurrentPerson = new Person();
            CurrentEmployee = new Employee();

            CurrentEmployee.BusinessEntityID = 0;
            CurrentEmployee.NationalIDNumber = "0";
            CurrentEmployee.MaritalStatus = 'S';
            CurrentEmployee.Gender = 'M';
            CurrentEmployee.rowguid = Guid.NewGuid();
            CurrentEmployee.ModifiedDate = DateTime.Today;

            CurrentPerson.rowguid = Guid.NewGuid();
            CurrentPerson.ModifiedDate = DateTime.Today;
            CurrentPerson.PersonType = "EM";
        }

        #endregion

    }

}


