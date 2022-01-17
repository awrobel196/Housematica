var _self = "undefined" != typeof window ? window : "undefined" != typeof WorkerGlobalScope && self instanceof WorkerGlobalScope ? self : {}, Prism = function (e) { var t = /\blang(?:uage)?-([\w-]+)\b/i, n = 0, a = { manual: e.Prism && e.Prism.manual, disableWorkerMessageHandler: e.Prism && e.Prism.disableWorkerMessageHandler, util: { encode: function e(t) { return t instanceof r ? new r(t.type, e(t.content), t.alias) : Array.isArray(t) ? t.map(e) : t.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/\u00a0/g, " ") }, type: function (e) { return Object.prototype.toString.call(e).slice(8, -1) }, objId: function (e) { return e.__id || Object.defineProperty(e, "__id", { value: ++n }), e.__id }, clone: function e(t, n) { var r, i, s = a.util.type(t); switch (n = n || {}, s) { case "Object": if (i = a.util.objId(t), n[i]) return n[i]; for (var l in r = {}, n[i] = r, t) t.hasOwnProperty(l) && (r[l] = e(t[l], n)); return r; case "Array": return i = a.util.objId(t), n[i] ? n[i] : (r = [], n[i] = r, t.forEach(function (t, a) { r[a] = e(t, n) }), r); default: return t } }, getLanguage: function (e) { for (; e && !t.test(e.className);)e = e.parentElement; return e ? (e.className.match(t) || [, "none"])[1].toLowerCase() : "none" }, currentScript: function () { if ("undefined" == typeof document) return null; if ("currentScript" in document) return document.currentScript; try { throw new Error } catch (a) { var e = (/at [^(\r\n]*\((.*):.+:.+\)$/i.exec(a.stack) || [])[1]; if (e) { var t = document.getElementsByTagName("script"); for (var n in t) if (t[n].src == e) return t[n] } return null } } }, languages: { extend: function (e, t) { var n = a.util.clone(a.languages[e]); for (var r in t) n[r] = t[r]; return n }, insertBefore: function (e, t, n, r) { var i = (r = r || a.languages)[e], s = {}; for (var l in i) if (i.hasOwnProperty(l)) { if (l == t) for (var o in n) n.hasOwnProperty(o) && (s[o] = n[o]); n.hasOwnProperty(l) || (s[l] = i[l]) } var u = r[e]; return r[e] = s, a.languages.DFS(a.languages, function (t, n) { n === u && t != e && (this[t] = s) }), s }, DFS: function e(t, n, r, i) { i = i || {}; var s = a.util.objId; for (var l in t) if (t.hasOwnProperty(l)) { n.call(t, l, t[l], r || l); var o = t[l], u = a.util.type(o); "Object" !== u || i[s(o)] ? "Array" !== u || i[s(o)] || (i[s(o)] = !0, e(o, n, l, i)) : (i[s(o)] = !0, e(o, n, null, i)) } } }, plugins: {}, highlightAll: function (e, t) { a.highlightAllUnder(document, e, t) }, highlightAllUnder: function (e, t, n) { var r = { callback: n, container: e, selector: 'code[class*="language-"], [class*="language-"] code, code[class*="lang-"], [class*="lang-"] code' }; a.hooks.run("before-highlightall", r), r.elements = Array.prototype.slice.apply(r.container.querySelectorAll(r.selector)), a.hooks.run("before-all-elements-highlight", r); for (var i, s = 0; i = r.elements[s++];)a.highlightElement(i, !0 === t, r.callback) }, highlightElement: function (n, r, i) { var s = a.util.getLanguage(n), l = a.languages[s]; n.className = n.className.replace(t, "").replace(/\s+/g, " ") + " language-" + s; var o = n.parentNode; o && "pre" === o.nodeName.toLowerCase() && (o.className = o.className.replace(t, "").replace(/\s+/g, " ") + " language-" + s); var u = { element: n, language: s, grammar: l, code: n.textContent }; function c(e) { u.highlightedCode = e, a.hooks.run("before-insert", u), u.element.innerHTML = u.highlightedCode, a.hooks.run("after-highlight", u), a.hooks.run("complete", u), i && i.call(u.element) } if (a.hooks.run("before-sanity-check", u), !u.code) return a.hooks.run("complete", u), void (i && i.call(u.element)); if (a.hooks.run("before-highlight", u), u.grammar) if (r && e.Worker) { var g = new Worker(a.filename); g.onmessage = function (e) { c(e.data) }, g.postMessage(JSON.stringify({ language: u.language, code: u.code, immediateClose: !0 })) } else c(a.highlight(u.code, u.grammar, u.language)); else c(a.util.encode(u.code)) }, highlight: function (e, t, n) { var i = { code: e, grammar: t, language: n }; return a.hooks.run("before-tokenize", i), i.tokens = a.tokenize(i.code, i.grammar), a.hooks.run("after-tokenize", i), r.stringify(a.util.encode(i.tokens), i.language) }, tokenize: function (e, t) { var n = t.rest; if (n) { for (var o in n) t[o] = n[o]; delete t.rest } var u = new i; return s(u, u.head, e), function e(t, n, i, o, u, c, g) { for (var d in i) if (i.hasOwnProperty(d) && i[d]) { var p = i[d]; p = Array.isArray(p) ? p : [p]; for (var f = 0; f < p.length; ++f) { if (g && g == d + "," + f) return; var m = p[f], h = m.inside, v = !!m.lookbehind, y = !!m.greedy, b = 0, F = m.alias; if (y && !m.pattern.global) { var x = m.pattern.toString().match(/[imsuy]*$/)[0]; m.pattern = RegExp(m.pattern.source, x + "g") } m = m.pattern || m; for (var k = o.next, w = u; k !== n.tail; w += k.value.length, k = k.next) { var A = k.value; if (n.length > t.length) return; if (!(A instanceof r)) { var P = 1; if (y && k != n.tail.prev) { m.lastIndex = w; var S = m.exec(t); if (!S) break; var $ = S.index + (v && S[1] ? S[1].length : 0), _ = S.index + S[0].length, j = w; for (j += k.value.length; $ >= j;)k = k.next, j += k.value.length; if (j -= k.value.length, w = j, k.value instanceof r) continue; for (var C = k; C !== n.tail && (j < _ || "string" == typeof C.value && !C.prev.value.greedy); C = C.next)P++, j += C.value.length; P--, A = t.slice(w, j), S.index -= w } else { m.lastIndex = 0; var S = m.exec(A) } if (S) { v && (b = S[1] ? S[1].length : 0); var $ = S.index + b, S = S[0].slice(b), _ = $ + S.length, N = A.slice(0, $), E = A.slice(_), z = k.prev; N && (z = s(n, z, N), w += N.length), l(n, z, P); var T = new r(d, h ? a.tokenize(S, h) : S, F, S, y); if (k = s(n, z, T), E && s(n, k, E), P > 1 && e(t, n, i, k.prev, w, !0, d + "," + f), c) break } else if (c) break } } } } }(e, u, t, u.head, 0), function (e) { var t = [], n = e.head.next; for (; n !== e.tail;)t.push(n.value), n = n.next; return t }(u) }, hooks: { all: {}, add: function (e, t) { var n = a.hooks.all; n[e] = n[e] || [], n[e].push(t) }, run: function (e, t) { var n = a.hooks.all[e]; if (n && n.length) for (var r, i = 0; r = n[i++];)r(t) } }, Token: r }; function r(e, t, n, a, r) { this.type = e, this.content = t, this.alias = n, this.length = 0 | (a || "").length, this.greedy = !!r } function i() { var e = { value: null, prev: null, next: null }, t = { value: null, prev: e, next: null }; e.next = t, this.head = e, this.tail = t, this.length = 0 } function s(e, t, n) { var a = t.next, r = { value: n, prev: t, next: a }; return t.next = r, a.prev = r, e.length++, r } function l(e, t, n) { for (var a = t.next, r = 0; r < n && a !== e.tail; r++)a = a.next; t.next = a, a.prev = t, e.length -= r } if (e.Prism = a, r.stringify = function e(t, n) { if ("string" == typeof t) return t; if (Array.isArray(t)) { var r = ""; return t.forEach(function (t) { r += e(t, n) }), r } var i = { type: t.type, content: e(t.content, n), tag: "span", classes: ["token", t.type], attributes: {}, language: n }, s = t.alias; s && (Array.isArray(s) ? Array.prototype.push.apply(i.classes, s) : i.classes.push(s)), a.hooks.run("wrap", i); var l = ""; for (var o in i.attributes) l += " " + o + '="' + (i.attributes[o] || "").replace(/"/g, "&quot;") + '"'; return "<" + i.tag + ' class="' + i.classes.join(" ") + '"' + l + ">" + i.content + "</" + i.tag + ">" }, !e.document) return e.addEventListener ? (a.disableWorkerMessageHandler || e.addEventListener("message", function (t) { var n = JSON.parse(t.data), r = n.language, i = n.code, s = n.immediateClose; e.postMessage(a.highlight(i, a.languages[r], r)), s && e.close() }, !1), a) : a; var o = a.util.currentScript(); function u() { a.manual || a.highlightAll() } if (o && (a.filename = o.src, o.hasAttribute("data-manual") && (a.manual = !0)), !a.manual) { var c = document.readyState; "loading" === c || "interactive" === c && o && o.defer ? document.addEventListener("DOMContentLoaded", u) : window.requestAnimationFrame ? window.requestAnimationFrame(u) : window.setTimeout(u, 16) } return a }(_self); "undefined" != typeof module && module.exports && (module.exports = Prism), "undefined" != typeof global && (global.Prism = Prism), Prism.languages.markup = { comment: /<!--[\s\S]*?-->/, prolog: /<\?[\s\S]+?\?>/, doctype: { pattern: /<!DOCTYPE(?:[^>"'[\]]|"[^"]*"|'[^']*')+(?:\[(?:(?!<!--)[^"'\]]|"[^"]*"|'[^']*'|<!--[\s\S]*?-->)*\]\s*)?>/i, greedy: !0 }, cdata: /<!\[CDATA\[[\s\S]*?]]>/i, tag: { pattern: /<\/?(?!\d)[^\s>\/=$<%]+(?:\s(?:\s*[^\s>\/=]+(?:\s*=\s*(?:"[^"]*"|'[^']*'|[^\s'">=]+(?=[\s>]))|(?=[\s\/>])))+)?\s*\/?>/i, greedy: !0, inside: { tag: { pattern: /^<\/?[^\s>\/]+/i, inside: { punctuation: /^<\/?/, namespace: /^[^\s>\/:]+:/ } }, "attr-value": { pattern: /=\s*(?:"[^"]*"|'[^']*'|[^\s'">=]+)/i, inside: { punctuation: [/^=/, { pattern: /^(\s*)["']|["']$/, lookbehind: !0 }] } }, punctuation: /\/?>/, "attr-name": { pattern: /[^\s>\/]+/, inside: { namespace: /^[^\s>\/:]+:/ } } } }, entity: /&#?[\da-z]{1,8};/i }, Prism.languages.markup.tag.inside["attr-value"].inside.entity = Prism.languages.markup.entity, Prism.hooks.add("wrap", function (e) { "entity" === e.type && (e.attributes.title = e.content.replace(/&amp;/, "&")) }), Object.defineProperty(Prism.languages.markup.tag, "addInlined", { value: function (e, t) { var n = {}; n["language-" + t] = { pattern: /(^<!\[CDATA\[)[\s\S]+?(?=\]\]>$)/i, lookbehind: !0, inside: Prism.languages[t] }, n.cdata = /^<!\[CDATA\[|\]\]>$/i; var a = { "included-cdata": { pattern: /<!\[CDATA\[[\s\S]*?\]\]>/i, inside: n } }; a["language-" + t] = { pattern: /[\s\S]+/, inside: Prism.languages[t] }; var r = {}; r[e] = { pattern: RegExp(/(<__[\s\S]*?>)(?:<!\[CDATA\[[\s\S]*?\]\]>\s*|[\s\S])*?(?=<\/__>)/.source.replace(/__/g, function () { return e }), "i"), lookbehind: !0, greedy: !0, inside: a }, Prism.languages.insertBefore("markup", "cdata", r) } }), Prism.languages.xml = Prism.languages.extend("markup", {}), Prism.languages.html = Prism.languages.markup, Prism.languages.mathml = Prism.languages.markup, Prism.languages.svg = Prism.languages.markup, function (e) { var t = /("|')(?:\\(?:\r\n|[\s\S])|(?!\1)[^\\\r\n])*\1/; e.languages.css = { comment: /\/\*[\s\S]*?\*\//, atrule: { pattern: /@[\w-]+[\s\S]*?(?:;|(?=\s*\{))/, inside: { rule: /^@[\w-]+/, "selector-function-argument": { pattern: /(\bselector\s*\((?!\s*\))\s*)(?:[^()]|\((?:[^()]|\([^()]*\))*\))+?(?=\s*\))/, lookbehind: !0, alias: "selector" } } }, url: { pattern: RegExp("url\\((?:" + t.source + "|[^\n\r()]*)\\)", "i"), greedy: !0, inside: { function: /^url/i, punctuation: /^\(|\)$/ } }, selector: RegExp("[^{}\\s](?:[^{};\"']|" + t.source + ")*?(?=\\s*\\{)"), string: { pattern: t, greedy: !0 }, property: /[-_a-z\xA0-\uFFFF][-\w\xA0-\uFFFF]*(?=\s*:)/i, important: /!important\b/i, function: /[-a-z0-9]+(?=\()/i, punctuation: /[(){};:,]/ }, e.languages.css.atrule.inside.rest = e.languages.css; var n = e.languages.markup; n && (n.tag.addInlined("style", "css"), e.languages.insertBefore("inside", "attr-value", { "style-attr": { pattern: /\s*style=("|')(?:\\[\s\S]|(?!\1)[^\\])*\1/i, inside: { "attr-name": { pattern: /^\s*style/i, inside: n.tag.inside }, punctuation: /^\s*=\s*['"]|['"]\s*$/, "attr-value": { pattern: /.+/i, inside: e.languages.css } }, alias: "language-css" } }, n.tag)) }(Prism), Prism.languages.clike = { comment: [{ pattern: /(^|[^\\])\/\*[\s\S]*?(?:\*\/|$)/, lookbehind: !0 }, { pattern: /(^|[^\\:])\/\/.*/, lookbehind: !0, greedy: !0 }], string: { pattern: /(["'])(?:\\(?:\r\n|[\s\S])|(?!\1)[^\\\r\n])*\1/, greedy: !0 }, "class-name": { pattern: /(\b(?:class|interface|extends|implements|trait|instanceof|new)\s+|\bcatch\s+\()[\w.\\]+/i, lookbehind: !0, inside: { punctuation: /[.\\]/ } }, keyword: /\b(?:if|else|while|do|for|return|in|instanceof|function|new|try|throw|catch|finally|null|break|continue)\b/, boolean: /\b(?:true|false)\b/, function: /\w+(?=\()/, number: /\b0x[\da-f]+\b|(?:\b\d+\.?\d*|\B\.\d+)(?:e[+-]?\d+)?/i, operator: /[<>]=?|[!=]=?=?|--?|\+\+?|&&?|\|\|?|[?*\/~^%]/, punctuation: /[{}[\];(),.:]/ }, Prism.languages.javascript = Prism.languages.extend("clike", { "class-name": [Prism.languages.clike["class-name"], { pattern: /(^|[^$\w\xA0-\uFFFF])[_$A-Z\xA0-\uFFFF][$\w\xA0-\uFFFF]*(?=\.(?:prototype|constructor))/, lookbehind: !0 }], keyword: [{ pattern: /((?:^|})\s*)(?:catch|finally)\b/, lookbehind: !0 }, { pattern: /(^|[^.]|\.\.\.\s*)\b(?:as|async(?=\s*(?:function\b|\(|[$\w\xA0-\uFFFF]|$))|await|break|case|class|const|continue|debugger|default|delete|do|else|enum|export|extends|for|from|function|get|if|implements|import|in|instanceof|interface|let|new|null|of|package|private|protected|public|return|set|static|super|switch|this|throw|try|typeof|undefined|var|void|while|with|yield)\b/, lookbehind: !0 }], number: /\b(?:(?:0[xX](?:[\dA-Fa-f](?:_[\dA-Fa-f])?)+|0[bB](?:[01](?:_[01])?)+|0[oO](?:[0-7](?:_[0-7])?)+)n?|(?:\d(?:_\d)?)+n|NaN|Infinity)\b|(?:\b(?:\d(?:_\d)?)+\.?(?:\d(?:_\d)?)*|\B\.(?:\d(?:_\d)?)+)(?:[Ee][+-]?(?:\d(?:_\d)?)+)?/, function: /#?[_$a-zA-Z\xA0-\uFFFF][$\w\xA0-\uFFFF]*(?=\s*(?:\.\s*(?:apply|bind|call)\s*)?\()/, operator: /--|\+\+|\*\*=?|=>|&&|\|\||[!=]==|<<=?|>>>?=?|[-+*\/%&|^!=<>]=?|\.{3}|\?[.?]?|[~:]/ }), Prism.languages.javascript["class-name"][0].pattern = /(\b(?:class|interface|extends|implements|instanceof|new)\s+)[\w.\\]+/, Prism.languages.insertBefore("javascript", "keyword", { regex: { pattern: /((?:^|[^$\w\xA0-\uFFFF."'\])\s])\s*)\/(?:\[(?:[^\]\\\r\n]|\\.)*]|\\.|[^\/\\\[\r\n])+\/[gimyus]{0,6}(?=(?:\s|\/\*[\s\S]*?\*\/)*(?:$|[\r\n,.;:})\]]|\/\/))/, lookbehind: !0, greedy: !0 }, "function-variable": { pattern: /#?[_$a-zA-Z\xA0-\uFFFF][$\w\xA0-\uFFFF]*(?=\s*[=:]\s*(?:async\s*)?(?:\bfunction\b|(?:\((?:[^()]|\([^()]*\))*\)|[_$a-zA-Z\xA0-\uFFFF][$\w\xA0-\uFFFF]*)\s*=>))/, alias: "function" }, parameter: [{ pattern: /(function(?:\s+[_$A-Za-z\xA0-\uFFFF][$\w\xA0-\uFFFF]*)?\s*\(\s*)(?!\s)(?:[^()]|\([^()]*\))+?(?=\s*\))/, lookbehind: !0, inside: Prism.languages.javascript }, { pattern: /[_$a-z\xA0-\uFFFF][$\w\xA0-\uFFFF]*(?=\s*=>)/i, inside: Prism.languages.javascript }, { pattern: /(\(\s*)(?!\s)(?:[^()]|\([^()]*\))+?(?=\s*\)\s*=>)/, lookbehind: !0, inside: Prism.languages.javascript }, { pattern: /((?:\b|\s|^)(?!(?:as|async|await|break|case|catch|class|const|continue|debugger|default|delete|do|else|enum|export|extends|finally|for|from|function|get|if|implements|import|in|instanceof|interface|let|new|null|of|package|private|protected|public|return|set|static|super|switch|this|throw|try|typeof|undefined|var|void|while|with|yield)(?![$\w\xA0-\uFFFF]))(?:[_$A-Za-z\xA0-\uFFFF][$\w\xA0-\uFFFF]*\s*)\(\s*)(?!\s)(?:[^()]|\([^()]*\))+?(?=\s*\)\s*\{)/, lookbehind: !0, inside: Prism.languages.javascript }], constant: /\b[A-Z](?:[A-Z_]|\dx?)*\b/ }), Prism.languages.insertBefore("javascript", "string", { "template-string": { pattern: /`(?:\\[\s\S]|\${(?:[^{}]|{(?:[^{}]|{[^}]*})*})+}|(?!\${)[^\\`])*`/, greedy: !0, inside: { "template-punctuation": { pattern: /^`|`$/, alias: "string" }, interpolation: { pattern: /((?:^|[^\\])(?:\\{2})*)\${(?:[^{}]|{(?:[^{}]|{[^}]*})*})+}/, lookbehind: !0, inside: { "interpolation-punctuation": { pattern: /^\${|}$/, alias: "punctuation" }, rest: Prism.languages.javascript } }, string: /[\s\S]+/ } } }), Prism.languages.markup && Prism.languages.markup.tag.addInlined("script", "javascript"), Prism.languages.js = Prism.languages.javascript, "undefined" != typeof self && self.Prism && self.document && document.querySelector && (self.Prism.fileHighlight = function (e) { e = e || document; var t = { js: "javascript", py: "python", rb: "ruby", ps1: "powershell", psm1: "powershell", sh: "bash", bat: "batch", h: "c", tex: "latex" }; Array.prototype.slice.call(e.querySelectorAll("pre[data-src]")).forEach(function (e) { if (!e.hasAttribute("data-src-loaded")) { for (var n, a = e.getAttribute("data-src"), r = e, i = /\blang(?:uage)?-([\w-]+)\b/i; r && !i.test(r.className);)r = r.parentNode; if (r && (n = (e.className.match(i) || [, ""])[1]), !n) { var s = (a.match(/\.(\w+)$/) || [, ""])[1]; n = t[s] || s } var l = document.createElement("code"); l.className = "language-" + n, e.textContent = "", l.textContent = "Loading…", e.appendChild(l); var o = new XMLHttpRequest; o.open("GET", a, !0), o.onreadystatechange = function () { 4 == o.readyState && (o.status < 400 && o.responseText ? (l.textContent = o.responseText, Prism.highlightElement(l), e.setAttribute("data-src-loaded", "")) : o.status >= 400 ? l.textContent = "✖ Error " + o.status + " while fetching file: " + o.statusText : l.textContent = "✖ Error: File does not exist or is empty") }, o.send(null) } }) }, document.addEventListener("DOMContentLoaded", function () { self.Prism.fileHighlight() })), function () { var e = Object.assign || function (e, t) { for (var n in t) t.hasOwnProperty(n) && (e[n] = t[n]); return e }; function t(t) { this.defaults = e({}, t) } function n(e) { for (var t = 0, n = 0; n < e.length; ++n)e.charCodeAt(n) == "\t".charCodeAt(0) && (t += 3); return e.length + t } t.prototype = { setDefaults: function (t) { this.defaults = e(this.defaults, t) }, normalize: function (t, n) { for (var a in n = e(this.defaults, n)) { var r = a.replace(/-(\w)/g, function (e, t) { return t.toUpperCase() }); "normalize" !== a && "setDefaults" !== r && n[a] && this[r] && (t = this[r].call(this, t, n[a])) } return t }, leftTrim: function (e) { return e.replace(/^\s+/, "") }, rightTrim: function (e) { return e.replace(/\s+$/, "") }, tabsToSpaces: function (e, t) { return t = 0 | t || 4, e.replace(/\t/g, new Array(++t).join(" ")) }, spacesToTabs: function (e, t) { return t = 0 | t || 4, e.replace(RegExp(" {" + t + "}", "g"), "\t") }, removeTrailing: function (e) { return e.replace(/\s*?$/gm, "") }, removeInitialLineFeed: function (e) { return e.replace(/^(?:\r?\n|\r)/, "") }, removeIndent: function (e) { var t = e.match(/^[^\S\n\r]*(?=\S)/gm); return t && t[0].length ? (t.sort(function (e, t) { return e.length - t.length }), t[0].length ? e.replace(RegExp("^" + t[0], "gm"), "") : e) : e }, indent: function (e, t) { return e.replace(/^[^\S\n\r]*(?=\S)/gm, new Array(++t).join("\t") + "$&") }, breakLines: function (e, t) { t = !0 === t ? 80 : 0 | t || 80; for (var a = e.split("\n"), r = 0; r < a.length; ++r)if (!(n(a[r]) <= t)) { for (var i = a[r].split(/(\s+)/g), s = 0, l = 0; l < i.length; ++l) { var o = n(i[l]); (s += o) > t && (i[l] = "\n" + i[l], s = o) } a[r] = i.join("") } return a.join("\n") } }, "undefined" != typeof module && module.exports && (module.exports = t), void 0 !== Prism && (Prism.plugins.NormalizeWhitespace = new t({ "remove-trailing": !0, "remove-indent": !0, "left-trim": !0, "right-trim": !0 }), Prism.hooks.add("before-sanity-check", function (e) { var t = Prism.plugins.NormalizeWhitespace; if (!e.settings || !1 !== e.settings["whitespace-normalization"]) if (e.element && e.element.parentNode || !e.code) { var n = e.element.parentNode, a = /(?:^|\s)no-whitespace-normalization(?:\s|$)/; if (e.code && n && "pre" === n.nodeName.toLowerCase() && !a.test(n.className) && !a.test(e.element.className)) { for (var r = n.childNodes, i = "", s = "", l = !1, o = 0; o < r.length; ++o) { var u = r[o]; u == e.element ? l = !0 : "#text" === u.nodeName && (l ? s += u.nodeValue : i += u.nodeValue, n.removeChild(u), --o) } if (e.element.children.length && Prism.plugins.KeepMarkup) { var c = i + e.element.innerHTML + s; e.element.innerHTML = t.normalize(c, e.settings), e.code = e.element.textContent } else e.code = i + e.code + s, e.code = t.normalize(e.code, e.settings) } } else e.code = t.normalize(e.code, e.settings) })) }(), Prism.plugins.NormalizeWhitespace.setDefaults({ "remove-trailing": !0, "remove-indent": !0, "left-trim": !0, "right-trim": !0 });