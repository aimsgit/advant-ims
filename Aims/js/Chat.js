var chats = new Array();
var top = 100;
var left = 100;
function OpenChatBox(uid, chatid) {
    
//     var letters = /^[A-Za-z]+$/;  
//      if(letters.test(uid))  
//      {  
//      var myString = new String(chatid);
//      var n=myString.split("_")
//      uid=n[1];
//      
//      }  
//      
//     	
////       var myString = new String(chatid);
////       var n=myString.split("_")
//       var userid=getCookie("userid")
//       if (userid==null || userid=="")
//       setCookie("userid",uid,1);
//       else if(userid!=uid)
//       uid=getCookie ("userid");
       
    var win = window.open("ChatBox.aspx?uid=" + uid + "&cid=" + chatid, "ChatWindow" + chatid + document.getElementById('hidCurrentUser').value, "status=0,toolbar=0, menubar=0, width=450,resizable=0, height=550");
    
    top = top + 50;
    if (top > screen.availHeight - 550)
        top = 100;
    left = left + 50;
    if (left > screen.availWidth - 450)
        left = 100;
    
    win.moveTo(left, top);
    chats[chats.length] = win;
    return false;
}

function closeChats() {
    for (iind = 0; iind < chats.length; iind++) {
            try
            {
                chats[iind].close();
            }
            catch(e){}
        }  
}



function getCookie(c_name)
{
var c_value = document.cookie;
var c_start = c_value.indexOf(" " + c_name + "=");
if (c_start == -1)
  {
  c_start = c_value.indexOf(c_name + "=");
  }
if (c_start == -1)
  {
  c_value = null;
  }
else
  {
  c_start = c_value.indexOf("=", c_start) + 1;
  var c_end = c_value.indexOf(";", c_start);
  if (c_end == -1)
    {
    c_end = c_value.length;
    }
  c_value = unescape(c_value.substring(c_start,c_end));
  }
return c_value;
}

function setCookie(c_name,value,exdays)
{
var exdate=new Date();
exdate.setDate(exdate.getDate() + exdays);
var c_value=escape(value) + ((exdays==null) ? "" : "; expires="+exdate.toUTCString());
document.cookie=c_name + "=" + c_value;
}

function checkCookie()
{

    setCookie("userid","",1);
    
}



function PingServer() {
    PingServerForMsg()
    setTimeout(PingServer, 5000);
}

var xmlHttp;
var requestURL = 'GetChatMsg.aspx';
var is_ie = (navigator.userAgent.indexOf('MSIE') >= 0) ? 1 : 0;
var is_ie5 = (navigator.appVersion.indexOf("MSIE 5.5") != -1) ? 1 : 0;
var is_opera = ((navigator.userAgent.indexOf("Opera6") != -1) || (navigator.userAgent.indexOf("Opera/6") != -1)) ? 1 : 0;
//netscape, safari, mozilla behave the same??? 
var is_netscape = (navigator.userAgent.indexOf('Netscape') >= 0) ? 1 : 0;

function PingServerForMsg() {
       //Append the name to search for to the requestURL 
        var url = requestURL;

        //Create the xmlHttp object to use in the request 
        //stateChangeHandler will fire when the state has changed, i.e. data is received back 
        // This is non-blocking (asynchronous) 
        xmlHttp = GetXmlHttpObject(stateChangeHandler);

        //Send the xmlHttp get to the specified url 
        xmlHttp_Get(xmlHttp, url);   
}

//stateChangeHandler will fire when the state has changed, i.e. data is received back 
// This is non-blocking (asynchronous) 
function stateChangeHandler() {
    //readyState of 4 or 'complete' represents that data has been returned 
    if (xmlHttp.readyState == 4 || xmlHttp.readyState == 'complete') {
        //Gather the results from the callback 
        var str = xmlHttp.responseText;

        if (str != "" ) {
            //document.getElementById('txtMsg').value = str;
            //eval(str);
            var msgs = str.split('#');

            for (ind = 0; ind < msgs.length; ind++) {
                msgs[ind] = msgs[ind].replace("_@HASH__", "#");
                var msg = msgs[ind].split("&");
                msg[0] = msg[0].replace("_@AMP__", "&");
                msg[1] = msg[1].replace("_@AMP__", "&");
                msg[2] = msg[2].replace("_@AMP__", "&");            
                var blnExisting = false;
                for (iind = 0; iind < chats.length; iind++) {
                    try
                    {
                        if (chats[iind] != null && chats[iind].name == "ChatWindow" + msg[1] + document.getElementById('hidCurrentUser').value)
                        blnExisting = true;
                    }
                    catch(e){}
                }  
                if( blnExisting == false)
                    OpenChatBox(msg[0], msg[1]);
            }
        }
    }
}

// XMLHttp send GET request 
function xmlHttp_Get(xmlhttp, url) {
    xmlhttp.open('GET', url, true);
    xmlhttp.send(null);
}

function GetXmlHttpObject(handler) {
    var objXmlHttp = null;    //Holds the local xmlHTTP object instance 

    //Depending on the browser, try to create the xmlHttp object 
    if (is_ie) {
        //The object to create depends on version of IE 
        //If it isn't ie5, then default to the Msxml2.XMLHTTP object 
        var strObjName = (is_ie5) ? 'Microsoft.XMLHTTP' : 'Msxml2.XMLHTTP';

        //Attempt to create the object 
        try {
            objXmlHttp = new ActiveXObject(strObjName);
            objXmlHttp.onreadystatechange = handler;
        }
        catch (e) {
            //Object creation errored 
            alert('IE detected, but object could not be created. Verify that active scripting and activeX controls are enabled');
            return;
        }
    }
    else if (is_opera) {
        //Opera has some issues with xmlHttp object functionality 
        alert('Opera detected. The page may not behave as expected.');
        return;
    }
    else {
        // Mozilla | Netscape | Safari 
        objXmlHttp = new XMLHttpRequest();
        objXmlHttp.onload = handler;
        objXmlHttp.onerror = handler;
    }

    //Return the instantiated object 
    return objXmlHttp;
} 