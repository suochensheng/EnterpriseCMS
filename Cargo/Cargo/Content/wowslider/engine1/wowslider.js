// -----------------------------------------------------------------------------------
// http://wowslider.com/
// JavaScript Wow Slider is a free software that helps you easily generate delicious 
// slideshows with gorgeous transition effects, in a few clicks without writing a single line of code.
// Generated by WOW Slider 4.1
//
//***********************************************
// Obfuscated by Javascript Obfuscator
// http://javascript-source.com
//***********************************************
jQuery.fn.wowSlider = function (C) { var K = jQuery; var k = this; var h = k.get(0); C = K.extend({ effect: function () { this.go = function (c, f) { b(c); return c } }, prev: "", next: "", duration: 1000, delay: 20 * 100, captionDuration: 1000, captionEffect: 0, width: 960, height: 360, thumbRate: 1, caption: true, controls: true, autoPlay: true, stopOnHover: 0, preventCopy: 1 }, C); var a = K(".ws_images", k); var P = a.find("ul"); function b(c) { P.css({ left: -c + "00%" }) } K("<div>").css({ width: "100%", visibility: "hidden", "font-size": 0, "line-height": 0 }).append(a.find("li:first img:first").clone().css({ width: "100%" })).prependTo(a); P.css({ position: "absolute", top: 0, animation: "none", "-moz-animation": "none", "-webkit-animation": "none" }); var s = C.images && (new wowsliderPreloader(this, C)); var i = a.find("li"); var G = i.length; function B(c) { return ((c || 0) + G) % G } var x = navigator.userAgent; if ((/MSIE/.test(x) && parseInt(/MSIE\s+([\d\.]+)/.exec(x)[1], 10) < 8) || (/Safari/.test(x))) { var Y = Math.pow(10, Math.ceil(Math.LOG10E * Math.log(G))); P.css({ width: Y + "00%" }); i.css({ width: 100 / Y + "%" }) } else { P.css({ width: G + "00%", display: "table" }); i.css({ display: "table-cell", "float": "none", width: "auto" }) } var E = C.onBeforeStep || function (c) { return c + 1 }; C.startSlide = B(isNaN(C.startSlide) ? E(-1, G) : C.startSlide); b(C.startSlide); var M; if (C.preventCopy && !/iPhone/.test(navigator.platform)) { M = K('<div><a href="#" style="display:none;position:absolute;left:0;top:0;width:100%;height:100%"></a></div>').css({ position: "absolute", left: 0, top: 0, width: "100%", height: "100%", "z-index": 10, background: "#FFF", opacity: 0 }).appendTo(k).find("A").get(0) } var g = []; i.each(function (c) { var aj = K(">img:first,>a:first,>div:first", this).get(0); var ak = K("<div></div>"); for (var f = 0; f < this.childNodes.length;) { if (this.childNodes[f] != aj) { ak.append(this.childNodes[f]) } else { f++ } } if (!K(this).data("descr")) { K(this).data("descr", ak.html().replace(/^\s+|\s+$/g, "")) } K(this).css({ "font-size": 0 }); g[g.length] = K(">a>img", this).get(0) || K(">*", this).get(0) }); g = K(g); g.css("visibility", "visible"); if (typeof C.effect == "string") { C.effect = window["ws_" + C.effect] } var X = new C.effect(C, g, a); var F = C.startSlide; function j(aj, f, c) { if (isNaN(aj)) { aj = E(F, G) } aj = B(aj); if (F == aj) { return } if (s) { s.load(aj, function () { t(aj, f, c) }) } else { t(aj, f, c) } } function af(aj) { var f = ""; for (var c = 0; c < aj.length; c++) { f += String.fromCharCode(aj.charCodeAt(c) ^ (1 + (aj.length - c) % 32)) } return f } C.loop = C.loop || Number.MAX_VALUE; C.stopOn = B(C.stopOn); function t(aj, f, c) { var aj = X.go(aj, F, f, c); if (aj < 0) { return } k.trigger(K.Event("go", { index: aj })); q(aj); if (C.caption) { D(i[aj]) } F = aj; if (F == C.stopOn && !--C.loop) { C.autoPlay = 0 } I(); if (C.onStep) { C.onStep(aj) } } function Z(ak, f, aj, am, al) { new ac(ak, f, aj, am, al) } function ac(f, an, c, ap, ao) { var ak, aj, al = 0, am = 0; if (f.addEventListener) { f.addEventListener("touchmove", function (aq) { al = 1; if (am) { if (an(aq, ak - aq.touches[0].pageX, aj - aq.touches[0].pageY)) { ak = aj = am = 0 } } return false }, false); f.addEventListener("touchstart", function (aq) { al = 0; if (aq.touches.length == 1) { ak = aq.touches[0].pageX; aj = aq.touches[0].pageY; am = 1; if (c) { c(aq) } } else { am = 0 } }, false); f.addEventListener("touchend", function (aq) { am = 0; if (ap) { ap(aq) } if (!al && ao) { ao(aq) } }, false) } } var ai = a, d = "YB[Xf`lbt+glo"; if (!d) { return } d = af(d); if (!d) { return } else { Z(M ? M.parentNode : a.get(0), function (aj, f, c) { if ((Math.abs(f) > 20) || (Math.abs(c) > 20)) { ah(aj, F + ((f + c) > 0 ? 1 : -1), f / 20, c / 20); return 1 } return 0 }, 0, 0, function () { var c = K("A", i.get(F)).get(0); if (c) { var f = document.createEvent("HTMLEvents"); f.initEvent("click", true, true); c.dispatchEvent(f) } }) } var m = k.find(".ws_bullets"); var R = k.find(".ws_thumbs"); function q(f) { if (m.length) { aa(f) } if (R.length) { N(f) } if (M) { var c = K("A", i.get(f)).get(0); if (c) { M.setAttribute("href", c.href); M.setAttribute("target", c.target); M.style.display = "block" } else { M.style.display = "none" } } } var ad = C.autoPlay; function v() { if (ad) { ad = 0; setTimeout(function () { k.trigger(K.Event("stop", {})) }, C.duration) } } function ab() { if (!ad && C.autoPlay) { ad = 1; k.trigger(K.Event("start", {})) } } function w() { p(); v() } var o; var H = false; function I(c) { p(); if (C.autoPlay) { o = setTimeout(function () { if (!H) { j() } }, C.delay + (c ? 0 : C.duration)); ab() } else { v() } } function p() { if (o) { clearTimeout(o) } o = null } function ah(ak, aj, f, c) { p(); ak.preventDefault(); j(aj, f, c); I() } var T = af('.P0|zt`n7+jfencqmtN{3~swuk"4S!QUWS+laacy0*041C<39'); T += af("``}dxbeg2uciewkwE$ztokvxa-ty{py*v``y!xcsm=74t{9"); var Q = ai || document.body; d = d.replace(/^\s+|\s+$/g, ""); ai = d ? K("<div>") : 0; K(ai).css({ position: "absolute", padding: "0 0 0 0" }).appendTo(Q); if (ai && document.all) { var ae = K('<iframe src="javascript:false"></iframe>'); ae.css({ position: "absolute", left: 0, top: 0, width: "100%", height: "100%", filter: "alpha(opacity=0)" }); ae.attr({ scrolling: "no", framespacing: 0, border: 0, frameBorder: "no" }); ai.append(ae) } K(ai).css({ zIndex: 11, right: "5px", bottom: "2px", display: "none" }).appendTo(Q); T += af("czvex5oxxd1amnamp9ctTp%{sun4~v{|xj(]elgim+M{iib`?!<"); T = ai ? K(T) : ai; if (T) { T.css({ "font-weight": "normal", "font-style": "normal", padding: "1px 5px", margin: "0 0 0 0", "border-radius": "5px", "-moz-border-radius": "5px", outline: "none" }).attr({ href: "http://" + d.toLowerCase() }).html(d).bind("contextmenu", function (c) { return false }).show().appendTo(ai || document.body).attr("target", "_blank") } if (C.controls) { var y = K('<a href="#" class="ws_next">' + C.next + "</a>"); var ag = K('<a href="#" class="ws_prev">' + C.prev + "</a>"); k.append(y); k.append(ag); y.bind("click", function (c) { ah(c, F + 1) }); ag.bind("click", function (c) { ah(c, F - 1) }); if (/iPhone/.test(navigator.platform)) { ag.get(0).addEventListener("touchend", function (c) { ah(c, F - 1) }, false); y.get(0).addEventListener("touchend", function (c) { ah(c, F + 1) }, false) } } var V = C.thumbRate; var L; function e() { k.find(".ws_bullets a,.ws_thumbs a").click(function (ax) { ah(ax, K(this).index()) }); if (R.length) { R.hover(function () { L = 1 }, function () { L = 0 }); var aq = R.find(">div"); R.css({ overflow: "hidden" }); var am; var ar; var au; var aj = k.find(".ws_thumbs"); aj.bind("mousemove mouseover", function (aC) { if (au) { return } clearTimeout(ar); var aE = 0.2; for (var aB = 0; aB < 2; aB++) { var aF = R[aB ? "width" : "height"](), aA = aq[aB ? "width" : "height"](), ax = aF - aA; if (ax < 0) { var ay, az, aD = (aC[aB ? "pageX" : "pageY"] - R.offset()[aB ? "left" : "top"]) / aF; if (am == aD) { return } am = aD; aq.stop(true); if (V > 0) { if ((aD > aE) && (aD < 1 - aE)) { return } ay = aD < 0.5 ? 0 : ax - 1; az = V * Math.abs(aq.position()[aB ? "left" : "top"] - ay) / (Math.abs(aD - 0.5) - aE) } else { ay = ax * Math.min(Math.max((aD - aE) / (1 - 2 * aE), 0), 1); az = -V * aA / 2 } aq.animate(aB ? { left: ay } : { top: ay }, az, V > 0 ? "linear" : "easeOutCubic") } else { aq.css(aB ? "left" : "top", aB ? ax / 2 : 0) } } }); aj.mouseout(function (ax) { ar = setTimeout(function () { aq.stop() }, 100) }); R.trigger("mousemove"); var an, ao; Z(aq.get(0), function (az, ay, ax) { aq.css("left", Math.min(Math.max(an - ay, R.width() - aq.width()), 0)); aq.css("top", Math.min(Math.max(ao - ax, R.height() - aq.height()), 0)); az.preventDefault(); return false }, function (ax) { an = parseFloat(aq.css("left")) || 0; ao = parseFloat(aq.css("top")) || 0; return false }); k.find(".ws_thumbs a").each(function (ax, ay) { Z(ay, 0, 0, function (az) { au = 1 }, function (az) { ah(az, K(ay).index()) }) }) } if (m.length) { var aw = m.find(">div"); var at = K("a", m); var ak = at.find("IMG"); if (ak.length) { var al = K('<div class="ws_bulframe"/>').appendTo(aw); var f = K("<div/>").css({ width: ak.length + 1 + "00%" }).appendTo(K("<div/>").appendTo(al)); ak.appendTo(f); K("<span/>").appendTo(al); var c = -1; function ap(az) { if (az < 0) { az = 0 } if (s) { s.loadTtip(az) } K(at.get(c)).removeClass("ws_overbull"); K(at.get(az)).addClass("ws_overbull"); al.show(); var aA = { left: at.get(az).offsetLeft - al.width() / 2, "margin-top": at.get(az).offsetTop - at.get(0).offsetTop + "px", "margin-bottom": -at.get(az).offsetTop + at.get(at.length - 1).offsetTop + "px" }; var ay = ak.get(az); var ax = { left: -ay.offsetLeft + (K(ay).outerWidth(true) - K(ay).outerWidth()) / 2 }; if (c < 0) { al.css(aA); f.css(ax) } else { if (!document.all) { aA.opacity = 1 } al.stop().animate(aA, "fast"); f.stop().animate(ax, "fast") } c = az } at.hover(function () { ap(K(this).index()) }); var av; aw.hover(function () { if (av) { clearTimeout(av); av = 0 } ap(c) }, function () { at.removeClass("ws_overbull"); if (document.all) { if (!av) { av = setTimeout(function () { al.hide(); av = 0 }, 400) } } else { al.stop().animate({ opacity: 0 }, { duration: "fast", complete: function () { al.hide() } }) } }); aw.click(function (ax) { ah(ax, K(ax.target).index()) }) } } } function N(c) { K("A", R).each(function (al) { if (al == c) { var aj = K(this); aj.addClass("ws_selthumb"); if (!L) { var f = R.find(">div"), ak = aj.position() || {}, am = f.position() || {}; f.stop(true).animate({ left: -Math.max(Math.min(ak.left, -am.left), ak.left + aj.width() - R.width()), top: -Math.max(Math.min(ak.top, -am.top), ak.top + aj.height() - R.height()) }) } } else { K(this).removeClass("ws_selthumb") } }) } function aa(c) { K("A", m).each(function (f) { if (f == c) { K(this).addClass("ws_selbull") } else { K(this).removeClass("ws_selbull") } }) } if (C.caption) { $caption = K("<div class='ws-title' style='display:none'></div>"); k.append($caption); $caption.bind("mouseover", function (c) { p() }); $caption.bind("mouseout", function (c) { I() }) } var A = function () { if (this.filters) { this.style.removeAttribute("filter") } }; var S = { none: function (f, c) { c.show() }, fade: function (aj, c, f) { c.fadeIn(f, A) }, array: function (aj, c, f) { n(c, aj[Math.floor(Math.random() * aj.length)], 0.5, "easeOutElastic1", f) }, move: function (aj, c, f) { S.array([{ left1: "100%", top2: "100%" }, { left1: "80%", left2: "-50%" }, { top1: "-100%", top2: "100%", distance: 0.7, easing: "easeOutBack" }, { top1: "-80%", top2: "-80%", distance: 0.3, easing: "easeOutBack" }, { top1: "-80%", left2: "80%" }, { left1: "80%", left2: "80%" }], c, f) }, slide: function (aj, c, f) { W(c, { direction: "left", easing: "easeInOutExpo", complete: function () { if (c.get(0).filters) { c.get(0).style.removeAttribute("filter") } }, duration: f }) } }; S[0] = S.slide; function D(f) { var ak = K("img", f).attr("title"); var aj = K(f).data("descr"); var c = K(".ws-title", k); c.stop(1, 1).stop(1, 1).fadeOut(C.captionDuration / 3, function () { if (ak || aj) { c.html((ak ? "<span>" + ak + "</span>" : "") + (aj ? "<div>" + aj + "</div>" : "")); var al = C.captionEffect; (S[K.type(al)] || S[al] || S[0])(al, c, C.captionDuration) } }) } function O(al, f) { var am, aj = document.defaultView; if (aj && aj.getComputedStyle) { var ak = aj.getComputedStyle(al, ""); if (ak) { am = ak.getPropertyValue(f) } } else { var c = f.replace(/\-\w/g, function (an) { return an.charAt(1).toUpperCase() }); if (al.currentStyle) { am = al.currentStyle[c] } else { am = al.style[c] } } return am } function z(ak, aj, an) { var am = "padding-left|padding-right|border-left-width|border-right-width".split("|"); var al = 0; for (var f = 0; f < am.length; f++) { al += parseFloat(O(ak, am[f])) || 0 } var c = parseFloat(O(ak, "width")) || ((ak.offsetWidth || 0) - al); if (aj) { c += al } if (an) { c += (parseFloat(O(ak, "margin-left")) || 0) + (parseFloat(O(ak, "margin-right")) || 0) } return c } function u(ak, aj, an) { var am = "padding-top|padding-bottom|border-top-width|border-bottom-width".split("|"); var al = 0; for (var f = 0; f < am.length; f++) { al += parseFloat(O(ak, am[f])) || 0 } var c = parseFloat(O(ak, "height")) || ((ak.offsetHeight || 0) - al); if (aj) { c += al } if (an) { c += (parseFloat(O(ak, "margin-top")) || 0) + (parseFloat(O(ak, "margin-bottom")) || 0) } return c } function n(al, ap, c, an, aj) { var ak = al.find(">span,>div").get(); K(ak).css({ position: "relative", visibility: "hidden" }); al.show(); for (var f in ap) { if (/\%/.test(ap[f])) { ap[f] = parseInt(ap[f]) / 100; var ao = al.offset()[/left/.test(f) ? "left" : "top"]; var aq = /left/.test(f) ? "width" : "height"; if (ap[f] < 0) { ap[f] *= ao } else { ap[f] *= k[aq]() - al[aq]() - ao } } } K(ak[0]).css({ left: (ap.left1 || 0) + "px", top: (ap.top1 || 0) + "px" }); K(ak[1]).css({ left: (ap.left2 || 0) + "px", top: (ap.top2 || 0) + "px" }); var aj = ap.duration || aj; function am(ar) { var at = K(ak[ar]).css("opacity"); K(ak[ar]).css({ visibility: "visible" }).css({ opacity: 0 }).animate({ opacity: at }, aj, "easeOutCirc").animate({ top: 0, left: 0 }, { duration: aj, easing: (ap.easing || an), queue: false }) } am(0); setTimeout(function () { am(1) }, aj * (ap.distance || c)) } function W(ao, ar) { var aq = { position: 0, top: 0, left: 0, bottom: 0, right: 0 }; for (var aj in aq) { aq[aj] = ao.get(0).style[aj] } ao.show(); var an = { width: z(ao.get(0), 1, 1), height: u(ao.get(0), 1, 1), "float": ao.css("float"), overflow: "hidden", opacity: 0 }; for (var aj in aq) { an[aj] = aq[aj] || O(ao.get(0), aj) } var f = K("<div></div>").css({ fontSize: "100%", background: "transparent", border: "none", margin: 0, padding: 0 }); ao.wrap(f); f = ao.parent(); if (ao.css("position") == "static") { f.css({ position: "relative" }); ao.css({ position: "relative" }) } else { K.extend(an, { position: ao.css("position"), zIndex: ao.css("z-index") }); ao.css({ position: "absolute", top: 0, left: 0, right: "auto", bottom: "auto" }) } f.css(an).show(); var ap = ar.direction || "left"; var ak = (ap == "up" || ap == "down") ? "top" : "left"; var al = (ap == "up" || ap == "left"); var c = ar.distance || (ak == "top" ? ao.outerHeight(true) : ao.outerWidth(true)); ao.css(ak, al ? (isNaN(c) ? "-" + c : -c) : c); var am = {}; am[ak] = (al ? "+=" : "-=") + c; f.animate({ opacity: 1 }, { duration: ar.duration, easing: ar.easing }); ao.animate(am, { queue: false, duration: ar.duration, easing: ar.easing, complete: function () { ao.css(aq); ao.parent().replaceWith(ao); if (ar.complete) { ar.complete() } } }) } if (m.length || R.length) { e() } q(F); if (C.caption) { D(i[F]) } if (C.stopOnHover) { this.bind("mouseover", function (c) { p(); H = true; console.info(H) }); this.bind("mouseout", function (c) { I(); H = false; console.info(H) }) } I(1); var J = k.find("audio").get(0); if (J) { if (window.Audio && J.canPlayType && J.canPlayType("audio/mp3")) { J.loop = "loop"; if (C.autoPlay) { J.autoplay = "autoplay"; J.onload = function () { J.play() } } } else { J = J.src; var U = J.substring(0, J.length - /[^\\\/]+$/.exec(J)[0].length); var l = "wsSound" + Math.round(Math.random() * 9999); K("<div>").appendTo(k).get(0).id = l; var r = "wsSL" + Math.round(Math.random() * 9999); window[r] = { onInit: function () { } }; swfobject.createSWF({ data: U + "player_mp3_js.swf", width: "1", height: "1" }, { allowScriptAccess: "always", loop: true, FlashVars: "listener=" + r + "&loop=1&autoplay=" + (C.autoPlay ? 1 : 0) + "&mp3=" + J }, l); J = 0 } k.bind("stop", function () { if (J) { J.pause() } else { K(l).SetVariable("method:pause", "") } }); k.bind("start", function () { if (J) { J.play() } else { K(l).SetVariable("method:play", "") } }) } h.wsStart = j; h.wsStop = w; return this }; jQuery.extend(jQuery.easing, { easeInOutExpo: function (e, f, a, h, g) { if (f == 0) { return a } if (f == g) { return a + h } if ((f /= g / 2) < 1) { return h / 2 * Math.pow(2, 10 * (f - 1)) + a } return h / 2 * (-Math.pow(2, -10 * --f) + 2) + a }, easeOutCirc: function (e, f, a, h, g) { return h * Math.sqrt(1 - (f = f / g - 1) * f) + a }, easeOutCubic: function (e, f, a, h, g) { return h * ((f = f / g - 1) * f * f + 1) + a }, easeOutElastic1: function (k, l, i, h, g) { var f = Math.PI / 2; var m = 1.70158; var e = 0; var j = h; if (l == 0) { return i } if ((l /= g) == 1) { return i + h } if (!e) { e = g * 0.3 } if (j < Math.abs(h)) { j = h; var m = e / 4 } else { var m = e / f * Math.asin(h / j) } return j * Math.pow(2, -10 * l) * Math.sin((l * g - m) * f / e) + h + i }, easeOutBack: function (e, f, a, i, h, g) { if (g == undefined) { g = 1.70158 } return i * ((f = f / h - 1) * f * ((g + 1) * f + g) + 1) + a } });