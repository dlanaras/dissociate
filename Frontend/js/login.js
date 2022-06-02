// JQUERY
$(function() {

    var images = ['../img/background1.png', '../img/background2.png', '../img/background3.png', '../img/background4.png', '../img/background5.png', '../img/background6.png', '../img/background7.png', '../img/background8.png', '../img/background9.png'];

    $('#container').append('<style>#container, .acceptContainer:before, #logoContainer:before {background: url(' + images[Math.floor(Math.random() * images.length)] + ') center fixed }');




    setTimeout(function() {
        $('.logoContainer').transition({ scale: 1 }, 700, 'ease');
        setTimeout(function() {
            $('.logoContainer .logo').addClass('loadIn');
            setTimeout(function() {
                $('.logoContainer .text').addClass('loadIn');
                setTimeout(function() {
                    $('.acceptContainer').transition({ height: '431.5px' });
                    setTimeout(function() {
                        $('.acceptContainer').addClass('loadIn');
                        setTimeout(function() {
                            $('.formDiv, form h1').addClass('loadIn');
                        }, 500)
                    }, 500)
                }, 500)
            }, 500)
        }, 1000)
    }, 10)
});