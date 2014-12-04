console.log('onehittaquitta');
var ClickCounterViewModel = function () {
    this.searchBox = ko.observable(); //ko is the JS object that he knockout js library provies. searchbox = to what got enetere in 
    this.searchResults = ko.observableArray();
    var self = this;
    this.searchClick = function() {

        $.ajax({
            url: '/api/Search',
            data: { search: this.searchBox() },
            type: 'GET',
            datatType: 'json',
            success: function (data) {
                console.log("post list results", data);
                data.forEach(function(book, index) {
                    book.imageTitle = "Cover of: " + book.Title;
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
};


ko.applyBindings(new ClickCounterViewModel());