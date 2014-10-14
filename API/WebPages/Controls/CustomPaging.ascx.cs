using System;
using System.Collections;

namespace RESTfulAPI.WebPages.Controls
{
    public partial class CustomPaging : System.Web.UI.UserControl
    {
        public delegate void onClick(object sender, System.EventArgs e);
        public event onClick ChangePageClick;

        private ArrayList IDArrayList;
        public ArrayList IDsArrayList
        {
            get { return IDArrayList; }
            set { ViewState["IDArrayList"] = value; }
        }

        public int JumpPageIndex
        {
            get { return JumpPage.SelectedIndex; }
            set { JumpPage.SelectedIndex = value; }
        }

        public string TotalRecordText
        {
            set { lbRecords.Text = value; }
        }

        public object GetDropDownRef
        {
            get { return JumpPage; }
        }

        public void SetButtonsCmdArgum(CustomPaging custom)
        {
            NextLink.CommandArgument = custom.NextLink.CommandArgument;
            LastLink.CommandArgument = custom.LastLink.CommandArgument;
            PreviousLink.CommandArgument = custom.PreviousLink.CommandArgument;
            FirstLink.CommandArgument = custom.FirstLink.CommandArgument;
            JumpPage.DataSource = custom.JumpPage.DataSource;
            JumpPage.DataBind();

            JumpPage.SelectedIndex = custom.JumpPage.SelectedIndex;
            lbTotalRecords.Text = custom.lbTotalRecords.Text;
            lbTotalPages.Text = custom.lbTotalPages.Text;

            JumpPage.Visible = custom.JumpPage.Visible;
            lbTotalPages.Visible = custom.lbTotalPages.Visible;

            NextLink.Visible = custom.NextLink.Visible;
            LastLink.Visible = custom.LastLink.Visible;
            PreviousLink.Visible = custom.PreviousLink.Visible;
            FirstLink.Visible = custom.FirstLink.Visible;
            lbRecords.Text = custom.lbRecords.Text;
        }

        // --------------------------------------------------------------
        // Displays appropriate page of data
        public void Paging(int WhichPage, int RecordsPerPage, int TotalRecords)
        {
            // Determine number of pages minus any leftover records
            long TotalPages = TotalRecords / RecordsPerPage;

            // If there are leftover records, increase page count by one
            if (TotalRecords % RecordsPerPage > 0)
            {
                TotalPages += 1;
            }

            // If current page does not fall within the valid range of pages
            if (WhichPage > TotalPages | WhichPage < 0)
            {
                // Call paging subroutine and reset to first page
                Paging(1, RecordsPerPage, TotalRecords);
                // If current page does fall within valid range of pages
            }
            else
            {
                // If current page is the last page, hide the "next" and "last" navigation links
                if (WhichPage == TotalPages)
                {
                    NextLink.Visible = false;
                    LastLink.Visible = false;
                }
                else
                {
                    NextLink.Visible = true;
                    LastLink.Visible = true;
                    NextLink.CommandArgument = (WhichPage + 1).ToString();
                    LastLink.CommandArgument = TotalPages.ToString();
                }

                // If current page is the first page, hide the "first" and "previous" navigation links	
                if (WhichPage == 1)
                {
                    PreviousLink.Visible = false;
                    FirstLink.Visible = false;
                }
                else
                {
                    PreviousLink.Visible = true;
                    FirstLink.Visible = true;
                    PreviousLink.CommandArgument = (WhichPage - 1).ToString();
                    FirstLink.CommandArgument = "1";
                }

                // Create ArrayList to store range of valid pages 
                ArrayList JumpPageList = new ArrayList();

                int x = 0;

                // Iterate through range of valid pages and add to ArrayList
                for (x = 1; x <= TotalPages; x++)
                {
                    JumpPageList.Add(x);
                }

                // Use this ArrayList to populate page navigation drop-down menu
                JumpPage.DataSource = JumpPageList;
                JumpPage.DataBind();

                if (JumpPage.Items.Count == 1)
                {
                    JumpPage.Visible = false;
                    lbTotalPages.Visible = false;
                }
                else
                {
                    JumpPage.Visible = true;
                    lbTotalPages.Visible = true;
                }

                // Select current page in drop-down menu
                JumpPage.SelectedIndex = WhichPage - 1;

                // Set the record count and page count text
                lbTotalRecords.Text = TotalRecords.ToString();
                lbTotalPages.Text = "/ " + TotalPages;
            }
        }

        #region "Paging"

        protected void ChangePage(object sender, EventArgs e)
        {
            if (ChangePageClick != null)
            {
                ChangePageClick(sender, e);
            }
        }

        public void ChangeBtnState(bool state)
        {
            NextLink.Visible = state;
            PreviousLink.Visible = state;
            LastLink.Visible = state;
            FirstLink.Visible = state;
            JumpPage.Visible = state;
            lbTotalPages.Visible = state;
        }

        // --------------------------------------------------------------
        // Displays appropriate page of data
        //public ArrayList PagingWithArrayList(int WhichPage = 1, int RecordsPerPage = 10)
        //{
        //    try
        //    {
        //        IDArrayList = ((ArrayList) ViewState["IDArrayList"]);

        //        // Determine total number of records
        //        int NumItems = IDArrayList.Count;

        //        // Set number of records per page
        //        int PageSize = RecordsPerPage;

        //        // Determine number of pages minus any leftover records
        //        long Pages = NumItems / PageSize;

        //        // Save this number for future reference
        //        long WholePages = NumItems / PageSize;

        //        // Determine number of leftover records
        //        int Leftover = NumItems % PageSize;

        //        // If there are leftover records, increase page count by one
        //        if (Leftover > 0)
        //        {
        //            Pages += 1;
        //        }

        //        int StartOfPage = 0;
        //        int EndOfPage = 0;

        //        // Set current page
        //        int CurrentPage = WhichPage;

        //        // If current page does not fall within the valid range of pages
        //        if (CurrentPage > Pages | CurrentPage < 0)
        //        {
        //            // Call paging subroutine and reset to first page
        //            return PagingWithArrayList(1, RecordsPerPage);

        //            // If current page does fall within valid range of pages
        //        }
        //        else
        //        {
        //            // If current page is the last page, hide the "next" and "last" navigation links
        //            if (CurrentPage == Pages)
        //            {
        //                NextLink.Visible = false;
        //                LastLink.Visible = false;

        //                // Otherwise, show the "next" and "last" navigation links and set the page index each will pass when clicked
        //            }
        //            else
        //            {
        //                NextLink.Visible = true;
        //                LastLink.Visible = true;
        //                NextLink.CommandArgument = (CurrentPage + 1).ToString();
        //                LastLink.CommandArgument = Pages.ToString();
        //            }

        //            // If current page is the first page, hide the "first" and "previous" navigation links	
        //            if (CurrentPage == 1)
        //            {
        //                PreviousLink.Visible = false;
        //                FirstLink.Visible = false;
        //                JumpPage.Visible = false;
        //                lbTotalPages.Visible = false;
        //                // Otherwise, show the "first" and "previous" navigation links and set the page index each will pass when clicked
        //            }
        //            else
        //            {
        //                PreviousLink.Visible = true;
        //                FirstLink.Visible = true;
        //                PreviousLink.CommandArgument = (CurrentPage - 1).ToString();
        //                FirstLink.CommandArgument = "1";
        //            }

        //            // Create ArrayList to store range of valid pages 
        //            object JumpPageList = new ArrayList();

        //            int x = 0;

        //            // Iterate through range of valid pages and add to ArrayList
        //            for (x = 1; x <= Pages; x++)
        //            {
        //                JumpPageList.Add(x);
        //            }

        //            // Use this ArrayList to populate page navigation drop-down menu
        //            JumpPage.DataSource = JumpPageList;
        //            JumpPage.DataBind();

        //            if (JumpPage.Items.Count == 1)
        //            {
        //                JumpPage.Visible = false;
        //                lbTotalPages.Visible = false;
        //            }
        //            else
        //            {
        //                JumpPage.Visible = true;
        //                lbTotalPages.Visible = true;
        //            }

        //            // Select current page in drop-down menu
        //            JumpPage.SelectedIndex = CurrentPage - 1;

        //            // Set the record count and page count text
        //            lbTotalRecords.Text = NumItems.ToString();
        //            lbTotalPages.Text = "/ " + Pages;

        //            // Determine the starting and ending index in the IDList ArrayList given the current page
        //            StartOfPage = PageSize * (CurrentPage - 1);
        //            EndOfPage = Math.Min((PageSize * (CurrentPage - 1)) + (PageSize - 1), ((WholePages * PageSize) + Leftover - 1));

        //            return IDArrayList.GetRange(StartOfPage, (EndOfPage - StartOfPage + 1));
        //        }
        //        //Module failed to load
        //    }
        //    catch (Exception exc)
        //    {
        //    }
        //}

        // --------------------------------------------------------------
        // Displays appropriate page of data

        public string PagingWithString(int WhichPage = 1, int RecordsPerPage = 10)
        {
            IDArrayList = ((ArrayList)ViewState["IDArrayList"]); ;

            // Determine total number of records
            int NumItems = IDArrayList.Count;

            // Set number of records per page
            int PageSize = RecordsPerPage;

            // Determine number of pages minus any leftover records
            long Pages = NumItems / PageSize;

            // Save this number for future reference
            long WholePages = NumItems / PageSize;

            // Determine number of leftover records
            int Leftover = NumItems % PageSize;

            // If there are leftover records, increase page count by one
            if (Leftover > 0)
            {
                Pages += 1;
            }

            int StartOfPage = 0;
            int EndOfPage = 0;

            // Set current page
            int CurrentPage = WhichPage;

            // If current page does not fall within the valid range of pages
            if (CurrentPage > Pages | CurrentPage < 0)
            {
                // Call paging subroutine and reset to first page
                return PagingWithString(1, RecordsPerPage);
                // If current page does fall within valid range of pages
            }
            else
            {
                // If current page is the last page, hide the "next" and "last" navigation links
                if (CurrentPage == Pages)
                {
                    NextLink.Visible = false;
                    LastLink.Visible = false;

                    // Otherwise, show the "next" and "last" navigation links and set the page index each will pass when clicked
                }
                else
                {
                    NextLink.Visible = true;
                    LastLink.Visible = true;
                    NextLink.CommandArgument = (CurrentPage + 1).ToString();
                    LastLink.CommandArgument = Pages.ToString();

                }

                // If current page is the first page, hide the "first" and "previous" navigation links	
                if (CurrentPage == 1)
                {
                    PreviousLink.Visible = false;
                    FirstLink.Visible = false;

                    // Otherwise, show the "first" and "previous" navigation links and set the page index each will pass when clicked
                }
                else
                {
                    PreviousLink.Visible = true;
                    FirstLink.Visible = true;
                    PreviousLink.CommandArgument = (CurrentPage - 1).ToString();
                    FirstLink.CommandArgument = "1";

                }

                // Create ArrayList to store range of valid pages 
                ArrayList JumpPageList = new ArrayList();

                int x = 0;

                // Iterate through range of valid pages and add to ArrayList
                for (x = 1; x <= Pages; x++)
                {
                    JumpPageList.Add(x);
                }

                // Use this ArrayList to populate page navigation drop-down menu
                JumpPage.DataSource = JumpPageList;
                JumpPage.DataBind();

                if (JumpPage.Items.Count == 1)
                {
                    JumpPage.Visible = false;
                    lbTotalPages.Visible = false;
                }
                else
                {
                    JumpPage.Visible = true;
                    lbTotalPages.Visible = true;
                }

                // Select current page in drop-down menu
                JumpPage.SelectedIndex = CurrentPage - 1;

                // Set the record count and page count text
                lbTotalRecords.Text = NumItems.ToString();
                lbTotalPages.Text = "/ " + Pages;

                // Determine the starting and ending index in the IDList ArrayList given the current page
                StartOfPage = PageSize * (CurrentPage - 1);
                EndOfPage = ((int)Math.Min((PageSize * (CurrentPage - 1)) + (PageSize - 1), ((WholePages * PageSize) + Leftover - 1)));

                return String.Join(",", IDArrayList.GetRange(StartOfPage, (EndOfPage - StartOfPage + 1)));
            }
        }

        //public Collections.Generic.List<eRM.Modules.eRMProject.eRMReqInfo> DivideListAsPageWithLinked(ArrayList IDArrayList, int pageSize, Collections.Generic.List<eRM.Modules.eRMProject.eRMReqInfo> lstReqInfoTemp)
        //{
        //    Collections.Generic.List<eRM.Modules.eRMProject.eRMReqInfo> lstReqInfo = new Collections.Generic.List<eRM.Modules.eRMProject.eRMReqInfo>();

        //    //delete duplicate toc's
        //    for (int k = 0; k <= lstReqInfoTemp.Count - 1; k++)
        //    {
        //        if (IsTocDuplicate(lstReqInfoTemp(k).TOCSection, lstReqInfo) == false)
        //        {
        //            lstReqInfo.Add(lstReqInfoTemp(k));
        //        }
        //    }

        //    int WhichPage = 1;
        //    // Determine total number of records
        //    int NumItems = IDArrayList.Count;

        //    // Save this number for future reference
        //    long WholePages = NumItems / pageSize;

        //    // Determine number of leftover records
        //    int Leftover = NumItems % pageSize;
        //    int CurrentPage = WhichPage;

        //    int StartOfPage = pageSize * (CurrentPage - 1);
        //    int EndOfPage = Math.Min((pageSize * (CurrentPage - 1)) + (pageSize - 1), ((WholePages * pageSize) + Leftover - 1));

        //    int StartOfPageTemp = 0;
        //    int EndOfPageTemp = 0;
        //    bool isMatch = false;
        //    int i = 0;
        //    int j = 0;

        //    for (int k = 0; k <= lstReqInfo.Count - 1; k++)
        //    {
        //        StartOfPageTemp = StartOfPage;
        //        EndOfPageTemp = EndOfPage;

        //        isMatch = false;
        //        WhichPage = 1;
        //        i = 0;

        //        while (i < IDArrayList.Count)
        //        {
        //            j = StartOfPageTemp;

        //            while (j <= EndOfPageTemp)
        //            {
        //                if (IDArrayList(j).ToString.Substring(0, IDArrayList(j).ToString.LastIndexOf("_")) == lstReqInfo(k).RequirementsID && IDArrayList(j).ToString.Substring(IDArrayList(j).ToString.LastIndexOf("_") + 1) == lstReqInfo(k).LinkId)
        //                {
        //                    lstReqInfo(k).PageNumber = WhichPage;
        //                    isMatch = true;
        //                    break; // TODO: might not be correct. Was : Exit While
        //                }

        //                j += 1;
        //            }

        //            if (isMatch)
        //                break; // TODO: might not be correct. Was : Exit While

        //            i = (pageSize * WhichPage);
        //            WhichPage += 1;
        //            StartOfPageTemp = pageSize * (WhichPage - 1);
        //            EndOfPageTemp = Math.Min((pageSize * (WhichPage - 1)) + (pageSize - 1), ((WholePages * pageSize) + Leftover - 1));
        //        }
        //    }

        //    return lstReqInfo;
        //}

        //public Collections.Generic.List<eRM.Modules.eRMProject.eRMReqInfo> DivideListAsPage(ArrayList IDArrayList, int pageSize, Collections.Generic.List<eRM.Modules.eRMProject.eRMReqInfo> lstReqInfoTemp)
        //{
        //    Collections.Generic.List<eRM.Modules.eRMProject.eRMReqInfo> lstReqInfo = new Collections.Generic.List<eRM.Modules.eRMProject.eRMReqInfo>();

        //    //delete duplicate toc's
        //    for (int k = 0; k <= lstReqInfoTemp.Count - 1; k++)
        //    {
        //        if (IsTocDuplicate(lstReqInfoTemp(k).TOCSection, lstReqInfo) == false)
        //        {
        //            lstReqInfo.Add(lstReqInfoTemp(k));
        //        }
        //    }

        //    int WhichPage = 1;
        //    // Determine total number of records
        //    int NumItems = IDArrayList.Count;

        //    // Save this number for future reference
        //    long WholePages = NumItems / pageSize;

        //    // Determine number of leftover records
        //    int Leftover = NumItems % pageSize;
        //    int CurrentPage = WhichPage;

        //    int StartOfPage = pageSize * (CurrentPage - 1);
        //    int EndOfPage = Math.Min((pageSize * (CurrentPage - 1)) + (pageSize - 1), ((WholePages * pageSize) + Leftover - 1));

        //    int StartOfPageTemp = 0;
        //    int EndOfPageTemp = 0;
        //    bool isMatch = false;
        //    int i = 0;
        //    int j = 0;

        //    for (int k = 0; k <= lstReqInfo.Count - 1; k++)
        //    {
        //        StartOfPageTemp = StartOfPage;
        //        EndOfPageTemp = EndOfPage;

        //        isMatch = false;
        //        WhichPage = 1;
        //        i = 0;

        //        while (i < IDArrayList.Count)
        //        {
        //            j = StartOfPageTemp;

        //            while (j <= EndOfPageTemp)
        //            {
        //                if (IDArrayList(j) == lstReqInfo(k).RequirementsID)
        //                {
        //                    lstReqInfo(k).PageNumber = WhichPage;
        //                    isMatch = true;
        //                    break; // TODO: might not be correct. Was : Exit While
        //                }

        //                j += 1;
        //            }

        //            if (isMatch)
        //                break; // TODO: might not be correct. Was : Exit While

        //            i = (pageSize * WhichPage);
        //            WhichPage += 1;
        //            StartOfPageTemp = pageSize * (WhichPage - 1);
        //            EndOfPageTemp = Math.Min((pageSize * (WhichPage - 1)) + (pageSize - 1), ((WholePages * pageSize) + Leftover - 1));
        //        }
        //    }

        //    return lstReqInfo;
        //}

        //public Collections.Generic.List<eRM.Modules.eRMProject.eRMRequirementsInfo> DivideListAsPage(ArrayList IDArrayList, int pageSize, Collections.Generic.List<eRM.Modules.eRMProject.eRMRequirementsInfo> lstReqInfoTemp)
        //{
        //    int WhichPage = 1;
        //    // Determine total number of records
        //    int NumItems = IDArrayList.Count;

        //    // Save this number for future reference
        //    long WholePages = NumItems / pageSize;

        //    // Determine number of leftover records
        //    int Leftover = NumItems % pageSize;
        //    int CurrentPage = WhichPage;

        //    int StartOfPage = pageSize * (CurrentPage - 1);
        //    int EndOfPage = Math.Min((pageSize * (CurrentPage - 1)) + (pageSize - 1), ((WholePages * pageSize) + Leftover - 1));

        //    int StartOfPageTemp = 0;
        //    int EndOfPageTemp = 0;
        //    bool isMatch = false;
        //    int i = 0;
        //    int j = 0;

        //    for (int k = 0; k <= lstReqInfoTemp.Count - 1; k++)
        //    {
        //        StartOfPageTemp = StartOfPage;
        //        EndOfPageTemp = EndOfPage;

        //        isMatch = false;
        //        WhichPage = 1;
        //        i = 0;

        //        while (i < IDArrayList.Count)
        //        {
        //            j = StartOfPageTemp;

        //            while (j <= EndOfPageTemp)
        //            {
        //                if (IDArrayList(j) == lstReqInfoTemp(k).RequirementsID)
        //                {
        //                    lstReqInfoTemp(k).UpdatedBy = WhichPage;
        //                    isMatch = true;
        //                    break; // TODO: might not be correct. Was : Exit While
        //                }

        //                j += 1;
        //            }

        //            if (isMatch)
        //                break; // TODO: might not be correct. Was : Exit While

        //            i = (pageSize * WhichPage);
        //            WhichPage += 1;
        //            StartOfPageTemp = pageSize * (WhichPage - 1);
        //            EndOfPageTemp = Math.Min((pageSize * (WhichPage - 1)) + (pageSize - 1), ((WholePages * pageSize) + Leftover - 1));
        //        }
        //    }

        //    return lstReqInfoTemp;
        //}

        // --------------------------------------------------------------
        // Displays appropriate page of data

        //public string PagingWithExt(ArrayList rowIndex, int WhichPage = 1, int RecordsPerPage = 10)
        //{

        //    try
        //    {
        //        ArrayList IDArrayList = ((ArrayList) ViewState["IDArrayList"]);;

        //        // Determine total number of records
        //        int NumItems = IDArrayList.Count;

        //        // Set number of records per page
        //        int PageSize = RecordsPerPage;

        //        // Determine number of pages minus any leftover records
        //        long Pages = NumItems / PageSize;

        //        // Save this number for future reference
        //        long WholePages = NumItems / PageSize;

        //        // Determine number of leftover records
        //        int Leftover = NumItems % PageSize;

        //        // If there are leftover records, increase page count by one
        //        if (Leftover > 0)
        //        {
        //            Pages += 1;
        //        }

        //        int StartOfPage = 0;
        //        int EndOfPage = 0;

        //        // Set current page
        //        int CurrentPage = WhichPage;

        //        // If current page does not fall within the valid range of pages

        //        if (CurrentPage > Pages | CurrentPage < 0)
        //        {
        //            // Call paging subroutine and reset to first page
        //            return PagingWithExt(rowIndex, 1, RecordsPerPage);

        //            // If current page does fall within valid range of pages
        //        }
        //        else
        //        {
        //            // If current page is the last page, hide the "next" and "last" navigation links

        //            if (CurrentPage == Pages)
        //            {
        //                NextLink.Visible = false;
        //                LastLink.Visible = false;

        //                // Otherwise, show the "next" and "last" navigation links and set the page index each will pass when clicked

        //            }
        //            else
        //            {
        //                NextLink.Visible = true;
        //                LastLink.Visible = true;
        //                NextLink.CommandArgument = CurrentPage + 1;
        //                LastLink.CommandArgument = Pages;

        //            }

        //            // If current page is the first page, hide the "first" and "previous" navigation links	

        //            if (CurrentPage == 1)
        //            {
        //                PreviousLink.Visible = false;
        //                FirstLink.Visible = false;

        //                // Otherwise, show the "first" and "previous" navigation links and set the page index each will pass when clicked

        //            }
        //            else
        //            {
        //                PreviousLink.Visible = true;
        //                FirstLink.Visible = true;
        //                PreviousLink.CommandArgument = (CurrentPage - 1).ToString();
        //                FirstLink.CommandArgument = "1";

        //            }

        //            // Create ArrayList to store range of valid pages 
        //            object JumpPageList = new ArrayList();

        //            int x = 0;

        //            // Iterate through range of valid pages and add to ArrayList
        //            for (x = 1; x <= Pages; x++)
        //            {
        //                JumpPageList.Add(x);
        //            }

        //            // Use this ArrayList to populate page navigation drop-down menu
        //            JumpPage.DataSource = JumpPageList;
        //            JumpPage.DataBind();

        //            // Select current page in drop-down menu
        //            JumpPage.SelectedIndex = CurrentPage - 1;

        //            // Set the record count and page count text
        //            lbTotalRecords.Text = NumItems.ToString();
        //            lbTotalPages.Text = "/ " + Pages;

        //            // Determine the starting and ending index in the IDList ArrayList given the current page
        //            StartOfPage = PageSize * (CurrentPage - 1);
        //            EndOfPage = Math.Min((PageSize * (CurrentPage - 1)) + (PageSize - 1), ((WholePages * PageSize) + Leftover - 1));

        //            // Retrieve the subset of primary key values that belong on the current page
        //            //GetAffItemTable(rowIndex, Join(IDArrayList.GetRange(StartOfPage, (EndOfPage - StartOfPage + 1)).ToArray, ","))
        //            return Strings.Join(IDArrayList.GetRange(StartOfPage, (EndOfPage - StartOfPage + 1)).ToArray, ",");
        //        }
        //        //Module failed to load
        //    }
        //    catch (Exception exc)
        //    {
        //    }
        //}

        #endregion

    }
}