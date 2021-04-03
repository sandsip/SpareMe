+function ($) {
    var timeoutID = null;
    function findMember(query) {
        //selected_genre_id = $(this).attr('value');
        // alert(query);
        var $wrap = $('.navbar-form .dropdown-menu')
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",

            url: "Index.aspx/GetSearcher",

            data: '{SearchElement: "' + query + '" }',

            beforeSend: function () {
                //alert("falied");
                $wrap.find('#ajax-search-loading').removeClass('hide');
                $wrap.find('#ajax-search-results').html('');
            },
            success: function (response) {
                //alert(response.val + "Testing");
                $wrap.find('#ajax-search-loading').addClass('hide');
                //$wrap.find('#ajax-search-results').html(response);

                var Searcher = $("[id*=ajax-search-results]");
                $("[id*=ajax-search-results]").html("");
                for (var i = 0; i < response.d.length; i++) {
                    //Searcher.append($("<a href=" + response.d[0].Value + " style='color: black;' class='text-ellipsis list-group-item'></a>").val(this['Value']).html(this['Text'])); ddlCustomers.append(
                    Searcher.append("<a ajax_target='#ajax_content_container' ajax_element='#ajax_element' href=" + response.d[i].URLLink + " style='color: black;' class='text-ellipsis list-group-item'>" +
                    "<span class='thumb-xs m-r-xs'><img width='150' height='150' src=" + response.d[i].imgpath + "></span>" +
                    "<span>" + response.d[i].MovieTitle + "</span></a>");
                }
                Searcher.html(rowHeader1);
            }
        });
    }

    $(document).on('keyup', '.navbar-form input', function (e) {
        var $target = $(this);
        if (!$target.val()) {
            if ($('#ajax-search').hasClass('open')) {
                $("#ajax-search-toggle").dropdown('toggle');
            }
            return;
        }
        if (!$('#ajax-search').hasClass('open')) {
            $("#ajax-search-toggle").dropdown('toggle');
        }
        clearTimeout(timeoutID);
        timeoutID = setTimeout(function () { findMember($target.val()); }, 500);
    });

}(jQuery);
