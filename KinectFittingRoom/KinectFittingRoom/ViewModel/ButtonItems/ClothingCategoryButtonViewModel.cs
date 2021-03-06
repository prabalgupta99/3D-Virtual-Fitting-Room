﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using KinectFittingRoom.Model.ClothingItems;

namespace KinectFittingRoom.ViewModel.ButtonItems
{
    public class ClothingCategoryButtonViewModel : ButtonViewModelBase
    {
        #region Private Fields
        /// <summary>
        /// Type of category
        /// </summary>
        private ClothingItemBase.MaleFemaleType _type;
        /// <summary>
        /// List of clothes in current category
        /// </summary>
        private List<ClothingButtonViewModel> _clothes;
        #endregion Private Fields
        #region Public Properties
        /// <summary>
        /// Gets or sets the clothes list.
        /// </summary>
        /// <value>
        /// The clothes list.
        /// </value>
        public List<ClothingButtonViewModel> Clothes
        {
            get { return _clothes; }
            set
            {
                if (_clothes == value)
                    return;
                _clothes = value;
                OnPropertyChanged("Clothes");
            }
        }
        /// <summary>
        /// Gets type of category
        /// </summary>
        public ClothingItemBase.MaleFemaleType Type
        {
            get { return _type; }
        }
        #endregion Public Properties
        #region Commands
        /// <summary>
        /// Executes when the Category button was hit.
        /// </summary>
        public override void ClickExecuted()
        {
            PlaySound();
            if (ClothingManager.Instance.Clothing != null && ClothingManager.Instance.Clothing.Count != 0 
                && ClothingManager.Instance.Clothing[0].Category == Clothes[0].Category)
                return;
            ClothingManager.Instance.LastChosenCategory = this;
            ClothingManager.Instance.Clothing = new ObservableCollection<ClothingButtonViewModel>();
            foreach (var cloth in Clothes)
                if (cloth.Type == ClothingManager.Instance.ChosenType || cloth.Type == ClothingItemBase.MaleFemaleType.Both)
                    ClothingManager.Instance.Clothing.Add(cloth);
        }
        #endregion Commands
        #region .ctor
        /// <summary>
        /// Initializes a new instance of the <see cref="ClothingCategoryButtonViewModel"/> class.
        /// </summary>
        /// <param name="type">Male or female type of category</param>
        public ClothingCategoryButtonViewModel(ClothingItemBase.MaleFemaleType type)
        {
            _type = type;
        }
        #endregion
    }
}
