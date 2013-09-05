using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ideas.DataModel
{
    public class Idea
    {
        #region Idea attributes: Title, Overview, Notes, System Requirements, Use Cases
        private int _uniqueId = -1;
        private string _Title;
        private string _Overview;
        private string _Notes;
        //private EntitySet<SystemRequirement> _SystemRequirements;
        //private EntitySet<UseCase> _UseCases;
        //private ObservableCollection<SystemRequirement> _SysReqsOC;
        //private ObservableCollection<UseCase> _UseCaseOC;
        #endregion
        private static Uri _baseUri = new Uri("ms-appx:///");

        public Idea()
        {
            Title = "";
            Overview = "";
            Notes = "";
        }

        #region Getters and setters
        public int UniqueId
        {
            get { return this._uniqueId; }
            set { _uniqueId = value; }
        }

        public string Title
        {
            get { return _Title; }
            set
            {
                if (_Title == value)
                    return;
                _Title = value;
                //NotifyPropertyChanged("Title");
            }
        }

        public string Overview
        {
            get { return _Overview; }
            set
            {
                _Overview = value;
                //NotifyPropertyChanged("Overview");

            }
        }


        public string Notes
        {
            get { return _Notes; }
            set
            {
                _Notes = value;
                // NotifyPropertyChanged("Notes");
            }
        }
        #endregion 
    }
}
