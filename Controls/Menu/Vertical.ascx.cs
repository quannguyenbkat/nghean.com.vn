using System;
using BIC.Biz;
using BIC.Entity;
using BIC.Utils;
using Telerik.Web.UI;


public partial class Controls_Menu_Vertical : BIC.WebControls.BaseUIControl
{
    public string _CssClass { get; set; }
    public int menuID { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        var menuUserEntity = MenuUserBiz.GetMenuUserByUrlName(BicRouting.GetRequestString("menu_name"));
        int menuUserId = 0;
        if (menuUserEntity != null)
            menuUserId = menuUserEntity.MenuUserId;
        var rootID = MenuUserBiz.GetRootIdByMenuUserID(menuUserId);
        var menuItems = MenuUserBiz.MenuUserGetRootByRootId(rootID);
        if (IsPostBack) return;
        //mncap.MenuUserId = menuID;
        //lbltext.Text = MenuUserBiz.GetNameById(menuID);

        foreach (var entity in menuItems)
        {
            if (entity.IsNew)
                entity.Name += string.Format(" <img src='{0}Styles/img/newicon.gif' />", BicApplication.URLRoot);

            var category = new RadMenuItem
                               {

                                   Text = entity.Name,
                                   Value = entity.MenuUserId.ToString(),
                                   NavigateUrl = entity.URL,
                                   Target = entity.Target,
                                   CssClass = " menu" + entity.MenuUserId
                               };

            if (menuUserId.Equals(entity.MenuUserId))
                category.CssClass += " expanded";
            else
            {
                var items = MenuUserBiz.GetNavigatePathById(menuUserId);
                if (items.Count > 1)
                    if (category.Text.Equals(items[0].Name))
                        category.CssClass += " expanded";

            }

            var panelItems = MenuUserBiz.GetByParentId(entity.MenuUserId);

            foreach (var panelEntity in panelItems)
            {
                if (panelEntity.IsNew)
                    panelEntity.Name += string.Format(" <img src='{0}Styles/img/newicon.gif' />",
                                                      BicApplication.URLRoot);
                var panelCategory = new RadMenuItem
                                        {
                                            Text = panelEntity.Name,
                                            Value = panelEntity.MenuUserId.ToString(),
                                            NavigateUrl = panelEntity.URL,
                                            Target = panelEntity.Target
                                        };
                category.Items.Add(panelCategory);
                if (menuUserId.Equals(panelEntity.MenuUserId))
                    panelCategory.CssClass += " expanded";
            }
            rpbMenu2.Items.Add(category);
        }
    }


}