
$(function () {
    $('.custom-select').select2(
        {

            width: '100%',
            language: {
                noResults: function () {
                    return "Sonuç bulunamadı!";  // Özelleştirilmiş 'no results' mesajı
                }
            }

        }
    );

    $('.custom-select').on('select2:open', function () {
        $('.select2-search__field').attr('placeholder', 'Ara..');
    });
});

