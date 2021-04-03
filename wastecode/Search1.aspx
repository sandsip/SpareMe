<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Search1.aspx.cs" Inherits="wastecode_Search1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="//code.jquery.com/jquery-1.11.0.min.js" type="text/javascript"></script>
    <link href="//netdna.bootstrapcdn.com/bootstrap/3.1.1/css/bootstrap.min.css" rel="stylesheet">
    <title></title>
    <script src="https://code.jquery.com/ui/1.11.4/jquery-ui.min.js" type="text/javascript"></script>
    <link href="https://code.jquery.com/ui/1.11.4/themes/start/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <style>
        .username {
            display: block;
            font-weight: bold;
            margin-bottom: 1em;
        }

        .userimage {
            float: left;
            max-height: 50px;
            max-width: 50px;
            margin-right: 10px;
        }

        .userinfo {
            margin: 0;
            padding: 0;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%=SelectedUsername.ClientID %>").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/Service.asmx/GetUsers") %>',
                        data: "{ 'input': '" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    username: item.Username,
                                    userid: item.UserID,
                                    info: item.AdditionalInfo,
                                    image: item.ImageURL
                                }
                            }))
                        }
                    });
                },
                minLength: 1,
                select: function (event, ui) {
                    $("#<%=SelectedUsername.ClientID %>").val(ui.item.username);
                    $("#<%=SelectedUserId.ClientID %>").val(ui.item.userid);
                    return false;
                }
            })
                         .autocomplete("instance")._renderItem = function (ul, item) {
                             return $("<li style='height:100px'>")
                            .append("<a><img class='userimage' src='" + item.image + "' class='img-rounded' />")
                            .append("<p class='username'>" + item.username + "</p>")
                            .append("<p class='userinfo'>" + item.info + "</p></a>")
                            .appendTo(ul);
                         };
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin: 100px">
            <asp:TextBox ID="SelectedUsername" runat="server"></asp:TextBox>
            <asp:HiddenField ID="SelectedUserId" runat="server" />
            <asp:Button ID="Process" runat="server" Text="Do whatever" />
        </div>
    </form>
</body>
</html>
