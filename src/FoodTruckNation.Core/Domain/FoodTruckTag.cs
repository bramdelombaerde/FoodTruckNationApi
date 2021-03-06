using Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodTruckNation.Core.Domain
{

    /// <summary>
    /// Represents a tag applied to a food truck
    /// </summary>
    public class FoodTruckTag : BaseEntity
    {

        internal FoodTruckTag() : base(ObjectState.UNCHANGED)
        {

        }


        protected internal FoodTruckTag(int id, FoodTruck foodTruck, Tag tag)
            : base(ObjectState.UNCHANGED)
        {
            _foodTruckTagId = id;
            FoodTruck = foodTruck;
            FoodTruckId = foodTruck.FoodTruckId;
            Tag = tag;
            TagId = tag.TagId;
        }


        public FoodTruckTag(FoodTruck foodTruck, Tag tag)
            : base(ObjectState.NEW)
        {
            FoodTruck = foodTruck;
            FoodTruckId = foodTruck.FoodTruckId;
            Tag = tag;
            TagId = tag.TagId;
        }


        private int? _foodTruckTagId;

        public int? FoodTruckTagId
        {
            get { return _foodTruckTagId;  }
            private set { _foodTruckTagId = value; }
        }

        public int FoodTruckId
        {
            get;
            private set;
        }

        public virtual FoodTruck FoodTruck
        {
            get;
            private set;
        }

        public int TagId
        {
            get;
            private set;
        }

        public virtual Tag Tag
        {
            get;
            private set;
        }


        internal void SetDeleted()
        {
            SetObjectDeleted();
        }

    }
}
