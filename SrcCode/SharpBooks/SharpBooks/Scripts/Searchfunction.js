$(function () {
    $('#submitBookSearch').on('click', function (e) {
        e.preventDefault();
        console.log('coffee');
        $.ajax({
            url: '/api/Search',
            data: { search: $('#Search').val() },
            type: 'GET',
            datatType: 'json',
            success: function (data) {
                console.log(data);
                $.each(data, function(index, value) {
                    $('#results').append('<li>' + value.Title + '</li>');

                });
            },
            fail:  function() {
                alert('something fucked up');
            }

        });

    });
});