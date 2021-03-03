<script>
    $(document).ready(function () {
        $('.btn-default').click(function () {
            var id = $(this).data("id");
            $.ajax({
                type: "POST",
                url: '/Cart/Buy',
                data: { Id: id },
                success: function (data) {
                }
            });
        });
    });
    function myFunction() {
      // Get the snackbar DIV
      var x = document.getElementById("snackbar");

    // Add the "show" class to DIV
    x.className = "show";

    // After 3 seconds, remove the show class from DIV
        setTimeout(function () {x.className = x.className.replace("show", ""); }, 3000);
}
</script>