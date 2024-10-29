namespace Spring_Microfinance_Management_System.Common.Const
{
    
    public static class CommonConst
    {
    
        public const int DEFAULT_MAX_SELECT_COUNT = 999;
       
        public const string SystemLoginLocation = "~/Common/SCRCM004A01_Login/";
     
        public const string SystemMenuLocation = "~/Common/SCRCM005A01_SystemMenu/";
       
        public const string ChangePasswordLocation = "~/Common/SCRCM008A01_ChangePassword/";
       
        public const string ParamSrc = "src";
      
        public const string ParamIsExecuteInitialSearch = "isExecuteInitialSearch";
      
        public const string ParamEditMode = "editMode";

        public const string DropdownListEmptyString = "--";

        public enum EditMode
        {           
            New,
            
            Modify,
           
            Delete,
        }
    }
    
    public class ViewDataParam
    {
        public const string Title = "Title";

        public const string ScreenId = "ScreenId";

        public const string ErrorMessage = "ErrorMessage";
    }
}
