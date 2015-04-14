/****************** Copyright Notice *****************

EISK Bread Menu v1.0.3

=======================================================
 
This code is licensed under Microsoft Public License (Ms-PL). 
You are free to use, modify and distribute any portion of this code. 
The only requirement to do that, you need to keep the developer name, as provided below to recognize and encourage original work:

=======================================================
   
Architecture Designed and Implemented By:
Mohammad Ashraful Alam
Microsoft Most Valuable Professional, ASP.NET 2007 – 2013
Twitter: http://twitter.com/AshrafulAlam | Blog: http://blog.ashraful.net | Portfolio: http://www.ashraful.net
   
*******************************************************/

//**************************************************************************
// Config Values
//**************************************************************************

var defaultParentManuId = 'ParentMenu'; 
var defaultChildMenuId = 'ChildMenuContainer';
var defaultParentManuAttributeForChildMenu = 'ChildMenuContainerId';
var enableMouseEvents = true;

//**************************************************************************
// Calling data binding method
//**************************************************************************

$(document).ready(function () { BindMenuItems(); });

//**************************************************************************
// Defining data binding methods
//**************************************************************************

function BindMenuItems() {
    
    HideSubMenus();
    LoadMenuByPath(location.pathname, true);

    //**************************************************************************
    // Handling mouse events
    //**************************************************************************

    if (enableMouseEvents == true) {
        $("#" + defaultParentManuId + ' a').mouseover(
            function () {
                HideSubMenus();
                var mouseHoverMenuPath = $(this).attr('href');
                LoadMenuByPath(mouseHoverMenuPath, false);
            }
        );  //mouseover ends

        //ISSUE: when the user mouse overs another menu during the mouse leave time, the mouseover functionality get lost! 
        $("#" + defaultParentManuId).mouseleave(
            function () {
                setTimeout(function () {
                    HideSubMenus();
                    LoadMenuByPath(location.pathname, true);
                }, 1000); //setTimeout ends
            }
        ); //mouseleave ends
    }
}  //BindMenuItems function ends

//**************************************************************************
// Utility methods
//**************************************************************************

function LoadMenuByPath(path, addStyle) {
    //find the path in child menu
    var item = $("#" + GetChildMenuContainerId()).find("a[href='" + path + "']");
    var itemIndex = $(item).parent().index();
    var parentItem = null;

    //if item was not found in the child menu, let's search it in parent menu
    if (itemIndex == -1) {
        item = $("#" + defaultParentManuId).find("a[href='" + path + "']");
        itemIndex = item.index();
    }
    else
        parentItem = $("#" + defaultParentManuId).children().eq(itemIndex);

    //if child or parent menu is found
    if (itemIndex != -1) {
        ShowSubMenu(itemIndex);
        if (addStyle == true) {
            //for child menu, it applies to child css, otherwise it applies to parent menu
            $(item).addClass('current');
            if (parentItem != null)
                $(parentItem).addClass('current');
        }
    }
} //LoadMenuByPath ends

function HideSubMenus() {
    //find the child menu container id
    var childMenuContainerId = GetChildMenuContainerId();
    $("#" + childMenuContainerId + " div").hide();
}  //HideSubMenus ends

function ShowSubMenu(showIndex) {
    var childMenuContainer = $("#" + GetChildMenuContainerId());
    if (childMenuContainer != null) {
        //show child-menu which corresponds to the index value of sub-menu container children
        var childMenuToShow = $(childMenuContainer).children().eq(showIndex);
        if (childMenuToShow != null)
            $(childMenuToShow).show();
    }
}  //ShowSubMenu ends

function GetChildMenuContainerId() {
    //find the child menu container id
    var childMenuContainerId = $("#" + defaultParentManuId).attr(defaultParentManuAttributeForChildMenu);
    //if no such child menu container id found, try with a default id 'ChildMenuContainer'
    if (childMenuContainerId == null)
        childMenuContainerId = defaultChildMenuId;

    return childMenuContainerId;
}  //GetChildMenuContainerId ends

