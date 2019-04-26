


//formatar data
var formatDateComplete = function (date) {

    if (typeof (date) == 'undefined' || date == "") return "";

    var dt = new Date(date);
    var d = dt.getDate();
    var m = dt.getMonth() + 1;
    var a = dt.getFullYear();
    var hh = dt.getHours();
    var mn = dt.getMinutes()
    
    return (d < 10 ? "0" : "") + d + "/" + (m < 10 ? "0" : "") + m + "/" + a + " " + (hh < 10 ? "0" : "") + hh + ":" + (mn < 10 ? "0" : "") + mn;

}



var IsNull = function(o, ret)
{
    if (typeof (o) == 'undefined') {
        return ret;
    } else {
        return o;
    }


}





/**
 * By Ken Fyrstenberg Nilsen
 *
 * drawImageProp(context, image [, x, y, width, height [,offsetX, offsetY]])
 *
 * If image and context are only arguments rectangle will equal canvas
*/
function drawImageProp(ctx, img, x, y, w, h, offsetX, offsetY) {

    if (arguments.length === 2) {
        x = y = 0;
        w = ctx.canvas.width;
        h = ctx.canvas.height;
    }

    // default offset is center
    offsetX = typeof offsetX === "number" ? offsetX : 0.5;
    offsetY = typeof offsetY === "number" ? offsetY : 0.5;

    // keep bounds [0.0, 1.0]
    if (offsetX < 0) offsetX = 0;
    if (offsetY < 0) offsetY = 0;
    if (offsetX > 1) offsetX = 1;
    if (offsetY > 1) offsetY = 1;

    var iw = img.width,
        ih = img.height,
        r = Math.min(w / iw, h / ih),
        nw = iw * r,   // new prop. width
        nh = ih * r,   // new prop. height
        cx, cy, cw, ch, ar = 1;

    // decide which gap to fill    
    if (nw < w) ar = w / nw;
    if (Math.abs(ar - 1) < 1e-14 && nh < h) ar = h / nh;  // updated
    nw *= ar;
    nh *= ar;

    // calc source rectangle
    cw = iw / (nw / w);
    ch = ih / (nh / h);

    cx = (iw - cw) * offsetX;
    cy = (ih - ch) * offsetY;

    // make sure source rectangle is valid
    if (cx < 0) cx = 0;
    if (cy < 0) cy = 0;
    if (cw > iw) cw = iw;
    if (ch > ih) ch = ih;

    // fill image in dest. rectangle
    ctx.drawImage(img, cx, cy, cw, ch, x, y, w, h);
}




var removerImagem = function (id) {

    //Limpa o canvas 
    document.getElementById(id).value = "";
    var canvas = document.getElementById(id + "_thumb");
    var ctx = canvas.getContext('2d');
    ctx.clearRect(0, 0, canvas.width, canvas.height);

    //Limpa o img 
    if (document.getElementById(id + "_img") != null) {
        document.getElementById(id + "_img").style.display = "none";
    }

    $("[class='"+ id +"_hidden']").val("")




}






function mensagem() {
    alert('Conteudo bloqueado!');
    return false;
}

function bloquearCopia(Event) {
    var Event = Event ? Event : window.event;
    var tecla = (Event.keyCode) ? Event.keyCode : Event.which;
    if (tecla == 17) {
        mensagem();
    }
}



