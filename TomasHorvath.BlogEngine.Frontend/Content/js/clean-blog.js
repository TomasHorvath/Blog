// Floating label headings for the contact form
$(function() {
    $("body").on("input propertychange", ".floating-label-form-group", function(e) {
        $(this).toggleClass("floating-label-form-group-with-value", !!$(e.target).val());
    }).on("focus", ".floating-label-form-group", function() {
        $(this).addClass("floating-label-form-group-with-focus");
    }).on("blur", ".floating-label-form-group", function() {
        $(this).removeClass("floating-label-form-group-with-focus");
    });
});

// Navigation Scripts to Show Header on Scroll-Up
jQuery(document).ready(function($) {
    var MQL = 1170;

    //primary navigation slide-in effect
    if ($(window).width() > MQL) {
        var headerHeight = $('.navbar-custom').height();
        $(window).on('scroll', {
                previousTop: 0
            },
            function() {
                var currentTop = $(window).scrollTop();
                //check if user is scrolling up
                if (currentTop < this.previousTop) {
                    //if scrolling up...
                    if (currentTop > 0 && $('.navbar-custom').hasClass('is-fixed')) {
                        $('.navbar-custom').addClass('is-visible');
                    } else {
                        $('.navbar-custom').removeClass('is-visible is-fixed');
                    }
                } else if (currentTop > this.previousTop) {
                    //if scrolling down...
                    $('.navbar-custom').removeClass('is-visible');
                    if (currentTop > headerHeight && !$('.navbar-custom').hasClass('is-fixed')) $('.navbar-custom').addClass('is-fixed');
                }
                this.previousTop = currentTop;
            });
    }

});


$(function () {

  $("#nextpost").click(function (e) {

    e.preventDefault();

    var next = $("#nextpost");
    var pageSize = next.data("pagesize");
    var pageIndex = next.data("nextpage");
    GetPages(pageSize, pageIndex);
  });

  $("#previouspost").click(function (e) {

    e.preventDefault();

    var previous = $("#previouspost");
    var pageSize = previous.data("pagesize");
    var pageIndex = previous.data("previouspage");
    GetPages(pageSize, pageIndex);
  });

});


function AppendPost(post)
{
  var template = "<div class='post-preview'><a href='"+post.Url+"'><h2 class='post-title'>"+post.Headline+"</h2><h3 class='post-subtitle'>"+post.Perex+"</h3></a><p class='post-meta'>Posted by <a href='#'>"+post.Author+"</a>"+post.DateOfPublish+"</p></div>";
  $("#blog-container").append(template);
}

function GetPages(PageSize, PageNumber)
{
  var url = "/?pageSize=" + PageSize + "&page=" + PageNumber;
  $.ajax({
    url: url,
    success: function (result) {

      $("#blog-container").empty();
      result.Items.forEach(function (current_value) {
        AppendPost(current_value);
      });

      // refresh paging
      if (result.HasPreviosPage)
      {
        $("#previouspost").data("pagesize", result.PageSize);
        $("#previouspost").data("previouspage", result.PageIndex - 1);
        $("#previouspost").css('visibility', 'visible');
      } else
      {
        $("#previouspost").css('visibility', 'hidden');
      }

      // 
      if (result.HasNextPage)
      {
        $("#nextpost").data("pagesize", result.PageSize);
        $("#nextpost").data("nextpage", result.PageIndex + 1);
        $("#nextpost").css('visibility', 'visible');
      
      } else
      {
        $("#nextpost").css('visibility', 'hidden');
      }
      
    }

  });
}