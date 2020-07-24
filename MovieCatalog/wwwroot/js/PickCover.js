class PickCover {

    CoverClassName = '.cover-img';
    CoverUrlInputClass = 'input.form-cover-url';

    constructor() {
        this.BindClickOnCovers();
    }

    BindClickOnCovers() {
        $(this.CoverClassName).off('click.PickCover');
        $(this.CoverClassName).on('click.PickCover', (e) => {
            let image = $(e.currentTarget);
            let url = image.attr('src');
            $(this.CoverUrlInputClass).val(url);
        });
    }

}

$(() => {
    var pickCover = new PickCover();
});