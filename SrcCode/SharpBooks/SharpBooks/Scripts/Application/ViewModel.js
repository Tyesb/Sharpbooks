var ClickCounterViewModel = function () {

    var self = this;
    this.searchBox = ko.observable(); //ko is the JS object that he knockout js library provies. searchbox = to what got enetere in 
    this.searchResults = ko.observableArray();
    this.bookShelfItems = ko.observableArray();
    this.moreInfo = function (book) {
        console.log("this book", book);
        book.detailsVisible(true);
    }
    this.searchClick = function () {

        $.ajax({
            url: '/api/Search',
            data: { search: this.searchBox() },
            type: 'GET',
            datatType: 'json',
            success: function (data) {
                data.forEach(function (book) {
                    book.detailsVisible = ko.observable(false);
                });
                self.searchResults(data);
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
            console.log("bread & butter");
        },
        fail: function () {
            alert('something up');
        }

    });
};


ko.applyBindings(new ClickCounterViewModel());

//$("#bookListWrapper").on("click", ".bookTitle", function(event) {
//    $(this).next(".bookImage").addClass("displayBookImage");
//    console.log("clicked on title");
//});