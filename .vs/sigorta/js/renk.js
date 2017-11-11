

$(document).ready(function() {

    //$("#d").addClass("active");
    //$("#d15").addClass("active");

    $('#TextBox1').keypress(function(event) {
        corenumericyap(event, "#TextBox1");
    });

    $('.button').button();

    $('#TextBox3').ColorPicker({
        onSubmit: function(hsb, hex, rgb, el) {
            $(el).val(hex);
            $(el).ColorPickerHide();
        },
        onBeforeShow: function() {
            $(this).ColorPickerSetColor(this.value);
        }
    })
    .bind('keyup', function() {
        $(this).ColorPickerSetColor(this.value);
    });


});
