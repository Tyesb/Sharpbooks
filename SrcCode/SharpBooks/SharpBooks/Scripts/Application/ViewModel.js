var ClickCounterViewModel = function () {

    var self = this;
    this.searchBox = ko.observable(); //ko is the JS object that he knockout js library provies. searchbox = to what got enetere in 
    this.searchResults = ko.observableArray();
    this.bookShelfItems = ko.observableArray();
    this.moreInfo = function (book) {
        var currentVisiblity = book.detailsVisible()
        book.detailsVisible(!currentVisiblity);
    }
    this.searchClick = function () {

        $.ajax({
            url: '/api/Search',
            data: { search: this.searchBox() },
            type: 'GET',
            datatType: 'json',
            success: function (data) {
                console.log("post list results", data);
                data.forEach(function(book, index) {
                    book.imageTitle = "Cover of: " + book.Title;
                    book.detailsVisible = ko.observable(false);
                });
                self.searchResults(data);
            },
            fail: function() {
                alert('something up');
            }

        });
    }

    this.addToBookShelf = function (book) {
        console.log("book is: ", book);
      

        $.ajax({
            url: '/api/Bookshelf',
            data: { ISBN: book.ISBN },
            type: 'POST',
            datatType: 'json',
            success: function (data) {
                console.log("post bookshelf results", data);
            },
            fail: function () {
                alert('something up');
            }

        });
    }
    var self = this;
    this.bookshelfitems = ko.observableArray();

    $.ajax({
        url: 'api/BookShelf',
        data: { search: $('#Search').val() },
        type: 'GET',
        datatType: 'json',
        success: function (data) {
            self.bookshelfitems(data);
        },
        fail: function () {
            alert('something up');
        }

    });
};


ko.applyBindings(new ClickCounterViewModel());