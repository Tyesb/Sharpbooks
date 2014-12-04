var BookshelfViewModel = function() {
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
}
ko.applyBindings(new BookshelfViewModel());
// GET: api/BookShelf

