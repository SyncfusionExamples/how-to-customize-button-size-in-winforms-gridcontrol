#region Copyright Syncfusion Inc. 2001 - 2014
// Copyright Syncfusion Inc. 2001 - 2014. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;

namespace DataGrid
{
	/// <summary>
	/// Summary description for Data.
	/// </summary>
	public class Data
	{
		public Data() : this("", "", "","","","","")
		{
		}

		public Data(string cat_Id, string cat_Name, string desc,string sample_Data,string value,string edit, string delete)
		{
			this.cat_Id = cat_Id;
			this.cat_Name = cat_Name;
			this.desc = desc;
            this.sample_Data = sample_Data;
            this.value = value;
            this.edit = edit;
            this.delete = delete;
		}
		private string cat_Name;
		public string CategoryName
		{
			get
			{
				return this.cat_Name;
			}
			set
			{
				this.cat_Name = value;
			}
		}
		private string cat_Id;
		public string CategoryID
		{
			get
			{
				return this.cat_Id;
			}
			set
			{
				this.cat_Id = value;
			}
		}
        private string desc;
        public string Description
        {
            get
            {
                return this.desc;
            }
            set
            {
                this.desc = value;
            }
        }
        private string sample_Data;
        public string SampleData
        {
            get
            {
                return this.sample_Data;
            }
            set
            {
                this.sample_Data = value;
            }
        }
        private string value;
        public string Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }
        private string edit;
        public string Edit
        {
            get
            {
                return this.edit;
            }
            set
            {
                this.edit = value;
            }
        }
        private string delete;
        public string Delete
        {
            get
            {
                return this.delete;
            }
            set
            {
                this.delete = value;
            }
        }

    }
}
