using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.ApplicationModel.Resources.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Ideas.Common;

namespace Ideas.Data
{
    [Windows.Foundation.Metadata.WebHostHidden]
    public abstract class Idea : Ideas.Common.BindableBase, INotifyPropertyChanged  
    {
        #region Idea attributes: Title, Overview, Notes, System Requirements, Use Cases
        private string _uniqueId = string.Empty;
        private string _Title;
        private string _Overview;
        private string _Notes;
        //private EntitySet<SystemRequirement> _SystemRequirements;
        //private EntitySet<UseCase> _UseCases;
        //private ObservableCollection<SystemRequirement> _SysReqsOC;
        //private ObservableCollection<UseCase> _UseCaseOC;
        #endregion
        private static Uri _baseUri = new Uri("ms-appx:///");
        public string IdeaUniqueId { get; set; }

        public Idea()
        {
            Title = "";
            Overview = "";
            Notes = ""; 
        }

        #region Getters and setters 
        public string UniqueId
        {
            get { return this._uniqueId; }
            set { this.SetProperty(ref this._uniqueId, value); }
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


        
        //private Idea _idea;
        //[IgnoreDataMember]
        //public Idea idea
        //{
        //    get
        //    {
        //        if (_idea == null)
        //            _idea = (Idea)IdeasDataSource.GetGroups().SingleOrDefault(n => n.UniqueId.Equals(this.IdeaUniqueId));

        //        return this._idea;
        //    }
        //    set
        //    {
        //        this.IdeaUniqueId = value.UniqueId;
        //        this.SetProperty(ref this._idea, value);
        //    }
        //}



    }

    /// <summary>
    /// Generic group data model.
    /// </summary>
    /// 
    public class Category
    {
        private ObservableCollection<Idea> _ideas;
        public ObservableCollection<Idea> Ideas
        {
            get { return _ideas; }
            set { _ideas = value; }
        }


    }

}