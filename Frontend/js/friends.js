var $ = document.querySelectorAll.bind(document);
$(".focusable, .button").forEach(function(el) {
    // blur only on mouse click
    // for accessibility, keep focus when keyboard focused
    el.addEventListener("mousedown", function(e) { return e.preventDefault(); });
    el.setAttribute("tabindex", "0");
});
$(".server").forEach(function(el) {
    el.addEventListener("click", function() {
        var activeServer = $(".server.active")[0];
        activeServer.classList.remove("active");
        activeServer.removeAttribute("aria-selected");
        el.classList.add("active");
        el.setAttribute("aria-selected", true);
    });
});
$(".channel-text").forEach(function(el) {
    el.addEventListener("click", function() {
        $(".channel-text.active")[0].classList.remove("active");
        el.classList.add("active");
    });
});