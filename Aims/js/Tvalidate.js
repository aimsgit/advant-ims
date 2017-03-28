//..............................................................................................................//
//                                             Javascript validation                                            //
//                                                 version 2.4.7                                                //
//                                            Advant Technologies Inc.                                          //
//                                                12 November, 2009                                             //
//..............................................................................................................//

//////////////////////////////////////////////////////
//Functions for the controls which is mandatory
//////////////////////////////////////////////////////
//NameField100(con,msg)
//CompareInt(con1,con2,msg1,msg2)
//Compare2String(con1,con2,msg1,msg2)
//Field30(con,msg)
//Field50(con,msg)
//Field250(con,msg)
//Field255(con,msg)
//CodeField(con,msg)
//YearField(con,msg)
//Duration(con,msg)
//YearPostal(con,msg)
//FeesFieldRestrictDecimal(con,msg)
//DropDown(con,msg)
//ValidateDate(con,msg)
//CompareDate(str1,str2,msg1,msg2)
//valcontact(con,msg)
//validateTimeDuration(con,msg)
//AutoCompleteExtender(con,msg)
//////////////////////////////////////////////////////
//Functions for the controls which is not mandatory
//////////////////////////////////////////////////////
//NameField100N(con,msg)
//Field30N(con,msg)
//Field50N(con,msg)
//Field250N(con,msg)
//Field255N(con,msg)
//CodeFieldN(con,msg)
//YearFieldN(con,msg)
//DurationN(con,msg)
//YearPostalN(con,msg)
//FeesFieldRestrictDecimalN(con,msg)
//DropDownN(con,msg)
//ValidateDateN(con,msg)
//valcontactN(con,msg)
//validateTimeDurationN(con,msg)
////////////////////////////////////////////////////////////
///Library function which are used to create above function
//////////////////////////////////////////////////////////

//validateStr(con,msg)
//validateName(con,msg)
//validateYear(con,msg)
//validateEmail(con,msg)
//minlength(con,minlen,msg)
//maxlength(con,minlen,msg)
//minmaxlength(con,minlen,maxlen,msg)
//minmaxValue(con,min,max,msg)
//numeric(con,msg)
//decimal(con,msg)
//mandatoryDate(con)
/////////////////////////////Variables/////////////////////
var stringObject = "";
var msg1 = "";
////////////////////////////AutoCompleteExtender//////////////////////
function AutoCompleteExtender(con, msg) {
    con.value = trim(con.value);
    if (con.value.length == 0) {
        return stringObject.concat(msg, " Field is Mandatory.");
    }
    if (con.value == "Type first few characters") {
        return stringObject.concat(msg, " Field is Mandatory.");
    }
    if (msg1 != "") return msg1;
    return "";
}

function AutoCompleteExtenderForThree(con, msg) {
    msg1 = ""
    con.value = trim(con.value);
    if (con.value.length == 0) {
        return stringObject.concat(msg, " Field is Mandatory.");
    }
    if (con.value == "Type first 3 characters") {
        return stringObject.concat(msg, " Field is Mandatory.");
    }
    if (msg1 != "") return msg1;
    return "";
}

function AutoCompleteExtenderN(con, msg) {
    con.value = trim(con.value);
    if (con.value.indexOf(":") == -1) {
        return stringObject.concat(msg, " Select from the below List.");
    }
    if (msg1 != "") return msg1;
    return "";
}
//////////////////////////To validate name Field//////////////////////
function Communication(con, msg) {
    con.value = trim(con.value);
    if (con.value == "Enter publisher Details" || con.value == "Enter message here") {
        return stringObject.concat(msg, " Field is Mandatory.");
    }
    msg1 = minmaxlength(con, 2, 8000, msg);
    if (msg1 != "") return msg1;
    // msg1 = validateName(con, msg);
    // if (msg1 != "") return msg1;
    return "";
}
//////////////////////////To validate name Field//////////////////////
function NameField100C(con, msg) {
    con.value = trim(con.value);
    if (con.value.length == 0) {
        return stringObject.concat(msg, " Field is Mandatory.");
    }
    msg1 = minmaxlength(con, 2, 8000, msg);
    if (msg1 != "") return msg1;
    msg1 = validateName(con, msg);
    if (msg1 != "") return msg1;
    return "";
}
function NameField100(con, msg) {
    con.value = trim(con.value);
    if (con.value.length == 0) {
        return stringObject.concat(msg, " Field is Mandatory.");
    }
    msg1 = minmaxlength(con, 2, 100, msg);
    if (msg1 != "") return msg1;
    msg1 = validateName(con, msg);
    if (msg1 != "") return msg1;
    return "";
}
function NameField1000(con, msg) {
    con.value = trim(con.value);
    if (con.value.length == 0) {
        return stringObject.concat(msg, " Field is Mandatory.");
    }
    msg1 = minmaxlength(con, 2, 1000, msg);
    if (msg1 != "") return msg1;
    msg1 = validateName(con, msg);
    if (msg1 != "") return msg1;
    return "";
}
function NameField100N(con, msg) {
    con.value = trim(con.value);
    if (con.value.length != 0)
        msg1 = minmaxlength(con, 2, 100, msg);
    if (msg1 != "") return msg1;
    msg1 = validateName(con, msg);
    if (msg1 != "") return msg1;
    return "";
}

function Feild250(con, msg) {
    con.value = trim(con.value);
    if (con.value.length == 0) {
        return stringObject.concat(msg, " Field is Mandatory.");
    }
    msg1 = minmaxlength(con, 1, 250, msg);
    if (msg1 != "") return msg1;
    msg1 = validateName(con, msg);
    if (msg1 != "") return msg1;
    return "";
}

//////////////////////////To validate Mobile No.  Field//////////////////////
function MobField(con, msg) {
    con.value = trim(con.value);
    if (con.value.length == 0) {
        return stringObject.concat(msg, " Field is Mandatory.");
    }
    msg1 = minmaxlength(con, 10, 20, msg);
    if (msg1 != "") return msg1;
    msg1 = validateName(con, msg);
    if (msg1 != "") return msg1;
    return "";
}
function MobFieldN(con, msg) {
    con.value = trim(con.value);
    if (con.value.length != 0)
        msg1 = minmaxlength(con, 10, 20, msg);
    if (msg1 != "") return msg1;
    msg1 = validateName(con, msg);
    if (msg1 != "") return msg1;
    return "";
}
////////////////////////////Compare two integers/////////////////            

function CompareInt(con1, con2, msg1, msg2) {
    var msg;
    msg = numeric(con1, msg1);
    if (msg != "") return msg;
    msg = decimal(con1, msg1);
    if (msg != "") return msg;
    msg = minmaxlength(con1, 1, 10, msg1);
    if (msg != "") return msg;
    msg = numeric(con2, msg2);
    if (msg != "") return msg;
    msg = decimal(con2, msg2);
    if (msg != "") return msg;
    msg = minmaxlength(con2, 1, 10, msg2);
    if (msg != "") return msg;
    if (parseInt(con1.value) > parseInt(con2.value)) {
        return stringObject.concat(msg1, " Should be lesser then ", msg2, ".");
    }
    return "";
}

////////////////////////////Compare Password or two string/////////////////            
function Compare2String(con1, con2, msg1, msg2) {
    con1.value = trim(con1.value);
    if (con1.value.length == 0) {
        return stringObject.concat(msg1, " Field is Mandatory.");
    }
    if (parseInt(con1.value) != parseInt(con2.value)) {
        return stringObject.concat(msg1, " Does not Match.");
    }
    return "";
}
/////////////////////////To validate  Field//////////////////////
//state
//country
//Designation
//city
function Field30(con, msg) {
    con.value = trim(con.value);
    if (con.value.length == 0) {
        return stringObject.concat(msg, " Field is Mandatory.");
    }
    msg1 = minmaxlength(con, 1, 30, msg);
    if (msg1 != "") return msg1;
    msg1 = validateName(con, msg);
    if (msg1 != "") return msg1;
    return "";
}
function Field30N(con, msg) {
    con.value = trim(con.value);
    if (con.value.length != 0)
        msg1 = minmaxlength(con, 2, 30, msg);
    if (msg1 != "") return msg1;
    msg1 = validateName(con, msg);
    if (msg1 != "") return msg1;
    return "";
}
/////////////////////////To validate  Field//////////////////////
//NIC No

function Field10(con, msg) {
    con.value = trim(con.value);
    if (con.value.length == 0) {
        return stringObject.concat(msg, " Field is Mandatory.");
    }
    msg1 = minmaxlength(con, 10, 10, msg);
    if (msg1 != "") return msg1;
    msg1 = validateName(con, msg);
    if (msg1 != "") return msg1;
    return "";
}
function Field10N(con, msg) {
    con.value = trim(con.value);
    if (con.value.length != 0)
        msg1 = minmaxlength(con, 10, 10, msg);
    if (msg1 != "") return msg1;
    msg1 = validateName(con, msg);
    if (msg1 != "") return msg1;
    return "";
}
//////////////////////////To validate Field//////////////////////
//Caste
//occupation
function Field50(con, msg) {
    con.value = trim(con.value);
    if (con.value.length == 0) {
        return stringObject.concat(msg, " Field is Mandatory.");
    }
    msg1 = minmaxlength(con, 2, 50, msg);
    if (msg1 != "") return msg1;
    msg1 = validateName(con, msg);
    if (msg1 != "") return msg1;
    return "";
}
function Field50N(con, msg) {
    con.value = trim(con.value);
    if (con.value.length != 0)
        msg1 = minmaxlength(con, 2, 50, msg);
    if (msg1 != "") return msg1;
    msg1 = validateName(con, msg);
    if (msg1 != "") return msg1;
    return "";
}
//////////////////////////To validate Field//////////////////////
//Address
//
function Field250(con, msg) {
    con.value = trim(con.value);
    if (con.value.length == 0) {
        return stringObject.concat(msg, " Field is Mandatory.");
    }
    msg1 = minmaxlength(con, 2, 250, msg);
    if (msg1 != "") return msg1;
    msg1 = validateName(con, msg);
    if (msg1 != "") return msg1;
    return "";
}
function Field250N(con, msg) {
    con.value = trim(con.value);
    if (con.value.length != 0)
        msg1 = minmaxlength(con, 2, 250, msg);
    if (msg1 != "") return msg1;
    msg1 = validateName(con, msg);
    if (msg1 != "") return msg1;
    return "";
}
//////////////////////////To validate Field//////////////////////
//Remarks
//Subject Description
function Field255(con, msg) {
    con.value = trim(con.value);
    if (con.value.length == 0) {
        return stringObject.concat(msg, " Field is Mandatory.");
    }
    msg1 = minmaxlength(con, 2, 255, msg);
    if (msg1 != "") return msg1;
    msg1 = validateName(con, msg);
    if (msg1 != "") return msg1;
    return "";
}
function Field255N(con, msg) {
    con.value = trim(con.value);
    if (con.value.length != 0)
        msg1 = minmaxlength(con, 2, 255, msg);
    if (msg1 != "") return msg1;
    msg1 = validateName(con, msg);
    if (msg1 != "") return msg1;
    return "";
}
//////////////////////////To validate code/ID Field//////////////////////
function CodeField(con, msg) {
    con.value = trim(con.value);
    if (con.value.length == 0) {
        return stringObject.concat(msg, " Field is Mandatory.");
    }
    msg1 = minmaxlength(con, 2, 15, msg);
    if (msg1 != "") return msg1;
    msg1 = validateStr(con, msg);
    if (msg1 != "") return msg1;
    return "";
}
function CodeFieldN(con, msg) {
    con.value = trim(con.value);
    if (con.value.length != 0)
        msg1 = minmaxlength(con, 3, 10, msg);
    if (msg1 != "") return msg1;
    msg1 = validateStr(con, msg);
    if (msg1 != "") return msg1;
    return "";
}
//////////////////////////To validate code/ID Field//////////////////////
function YearField(con, msg) {
    con.value = trim(con.value);
    if (con.value.length == 0) {
        return stringObject.concat(msg, " Field is Mandatory.");
    }
    msg1 = validateYear(con, msg);
    if (msg1 != "") return msg1;
    return "";
}
function YearFieldN(con, msg) {
    con.value = trim(con.value);
    msg1 = validateYear(con, msg);
    if (msg1 != "") return msg1;
    return "";
}

/////////////////////////To validate  Field//////////////////////
//Single character

function Field1(con, msg) {
    con.value = trim(con.value);
    if (con.value.length == 0) {
        return stringObject.concat(msg, " Field is Mandatory.");
    }
    msg1 = minmaxlength(con, 1, 6, msg);
    if (msg1 != "") return msg1;
    msg1 = validateName(con, msg);
    if (msg1 != "") return msg1;
    return "";
}

//6,15 Password field 

function SixChar(con, msg) {
    con.value = trim(con.value);
    if (con.value.length == 0) {
        return stringObject.concat(msg, " Field is Mandatory.");
    }
    msg1 = minmaxlength(con, 6, 15, msg);
    if (msg1 != "") return msg1;
    msg1 = validateName(con, msg);
    if (msg1 != "") return msg1;
    return "";
}

//Single number
function OneChar(con, msg) {
    con.value = trim(con.value);
    if (con.value.length == 0) {
        return stringObject.concat(msg, " Field is Mandatory.");
    }
    msg1 = minmaxlength(con, 1, 50, msg);
    if (msg1 != "") return msg1;
    msg1 = validateName(con, msg);
    if (msg1 != "") return msg1;
    return "";
}

function Dateone(con, msg) {
    //            if(mandatoryDate(con)=="")
    //            return stringObject.concat(msg, " Is Mandatory.");
    var dt1 = parseInt(con.value.substring(0, 2), 10);
    var temp1 = con.value.substring(3, 6);
    if (!getMonthvalue(temp1)) {
        return stringObject.concat(msg, " Is not a valid Date.");
    }
    return "";
}


function OneCharN(con, msg) {
    con.value = trim(con.value);
    //              if(con.value.length == 0) {
    //               return stringObject.concat(msg," Field is Mandatory.");
    //              }
    msg1 = minmaxlength(con, 1, 3, msg);
    if (msg1 != "") return msg1;
    msg1 = validateName(con, msg);
    if (msg1 != "") return msg1;
    return "";
}

/////////////////////////To validate Duration Field//////////////////////
function Duration(con, msg) {
    con.value = trim(con.value);
    if (con.value.length == 0) {
        return stringObject.concat(msg, " Field is Mandatory.");
    }
    msg1 = numeric(con, msg);
    if (msg1 != "") return msg1;
    return "";
}
function DurationN(con, msg) {
    con.value = trim(con.value);
    msg1 = numeric(con, msg);
    if (msg1 != "") return msg1;
    return "";
}
/////////////////////////To validate Postal Code Field//////////////////////
function YearPostal(con, msg) {
    con.value = trim(con.value);
    if (con.value.length == 0) {
        return stringObject.concat(msg, " Field is Mandatory.");
    }
    msg1 = numeric(con, msg);
    if (msg1 != "") return msg1;
    msg1 = minmaxlength(con, 6, 6, msg);
    if (msg1 != "") return msg1;
    return "";
}

function YearPostalN(con, msg) {
    con.value = trim(con.value);
    msg1 = numeric(con, msg);
    if (msg1 != "") return msg1;
    if (con.value.length != 0)
        msg1 = minmaxlength(con, 6, 6, msg);
    if (msg1 != "") return msg1;
    return "";
}
//////////////////////////To validate age field///////////////////////
//yashika
function AgeField(con, msg) {
    con.value = trim(con.value);
    if (con.value.length == 0) {
        return stringObject.concat(msg, " Field is Mandatory.");
    }
    msg1 = numeric(con, msg);
    if (msg1 != "") return msg1;
    msg1 = minmaxlength(con, 0, 3, msg);
    if (msg1 != "") return msg1;
    return "";
}
function AgeFieldN(con, msg) {
    con.value = trim(con.value);
    msg1 = numeric(con, msg);
    if (msg1 != "") return msg1;
    if (con.value.length != 0)
        msg1 = minmaxlength(con, 0, 3, msg);
    if (msg1 != "") return msg1;
    return "";
}
/////////////////////////To validate year field//////////////////////
//yashika
function YearField(con, msg) {
    con.value = trim(con.value);
    if (con.value.length == 0) {
        return stringObject.concat(msg, " Field is Mandatory.");
    }
    msg1 = numeric(con, msg);
    if (msg1 != "") return msg1;
    msg1 = minmaxlength(con, 4, 4, msg);
    if (msg1 != "") return msg1;
    return "";
}
/////////////////////////To validate telephone No(Not mandatory)///////
function TeleFieldN(con, msg) {
    con.value = trim(con.value);
    msg1 = numeric(con, msg);
    if (msg1 != "") return msg1;
    if (con.value.length != 0)
        msg1 = minmaxlength(con, 10, 10, msg);
    if (msg1 != "") return msg1;
    return "";
}
/////////////////////////To Validate Pin code////////////////////////
//yashika
function PinCodeField(con, msg) {
    con.value = trim(con.value);
    if (con.value.length == 0) {
        return stringObject.concat(msg, " Field is Mandatory.");
    }
    msg1 = numeric(con, msg);
    if (msg1 != "") return msg1;
    msg1 = minmaxlength(con, 6, 6, msg);
    if (msg1 != "") return msg1;
    return "";
}
//Raju for Rural Bank Code
function PinCodeFieldRural(con, msg) {
    con.value = trim(con.value);
    if (con.value.length == 0) {
        return stringObject.concat(msg, " Field is Mandatory.");
    }
    msg1 = numeric(con, msg);
    if (msg1 != "") return msg1;
    msg1 = minmaxlength(con, 2, 10, msg);
    if (msg1 != "") return msg1;
    return "";
}
/////////////////////////To validate Fees Field//////////////////////             
function FeesField(con, msg) {
    con.value = trim(con.value);
    if (con.value < 0) {
        return stringObject.concat(msg, " Field is Mandatory.");
    }
    msg1 = numeric(con, msg);
    if (msg1 != "") return msg1;
    msg1 = minmaxlength(con, 1, 10, msg);
    if (msg1 != "") return msg1;
    return "";
}
function FeesFieldN(con, msg) {
    con.value = trim(con.value);
    msg1 = numeric(con, msg);
    if (msg1 != "") return msg1;
    if (con.value.length != 0)
        msg1 = minmaxlength(con, 1, 10, msg);
    if (msg1 != "") return msg1;
    return "";
}

/////////////////////////To validate Fees Field with decimal//////////////////////             
function FeesFieldAcceptDecimal(con, msg) {
    con.value = trim(con.value);
    if (con.value == 0) {
        return stringObject.concat(msg, " Field is Mandatory.");
    }
    msg1 = Acceptdecimal(con, msg);
    if (msg1 != "") return msg1;
    msg1 = minmaxlength(con, 1, 20, msg);
    if (msg1 != "") return msg1;
    return "";
}

function FeesFieldAcceptDecimalN(con, msg) {
    con.value = trim(con.value);
    msg1 = Acceptdecimal(con, msg);
    if (msg1 != "") return msg1;
    if (con.value.length != 0)
        msg1 = minmaxlength(con, 1, 10, msg);
    if (msg1 != "") return msg1;
    return "";
}
/////////////////////////To validate Fees Field restrict decimal//////////////////////             
function FeesFieldRestrictDecimal(con, msg) {
    con.value = trim(con.value);
    if (con.value == 0) {
        return stringObject.concat(msg, " Field is Mandatory.");
    }
    msg1 = numeric(con, msg);
    if (msg1 != "") return msg1;
    msg1 = decimal(con, msg);
    if (msg1 != "") return msg1;
    msg1 = minmaxlength(con, 1, 10, msg);
    if (msg1 != "") return msg1;
    return "";
}
function FeesFieldRestrictDecimalN(con, msg) {
    con.value = trim(con.value);
    msg1 = numeric(con, msg);
    if (msg1 != "") return msg1;
    msg1 = decimal(con, msg);
    if (msg1 != "") return msg1;
    if (con.value.length != 0)
        msg1 = minmaxlength(con, 1, 10, msg);
    if (msg1 != "") return msg1;
    return "";
}
/////////////////////////To validate Dropdown selected or not//////////////////////   
function DropDown(con, msg) {
    con.value = trim(con.value);
    if (con.value.length == 0) {
        return stringObject.concat(msg, " Field is Mandatory.");
    }
    if (con.value.match(/^Select$/)) {
        return stringObject.concat(msg, " Field is Mandatory.");
    }
    return "";
}
function DropDownForZero(con, msg) {
    con.value = trim(con.value);
    if (con.value.length == 0) {
        return stringObject.concat(msg, " Field is Mandatory.");
    }
    if (con.value.match(/^0$/)) {
        return stringObject.concat(msg, " Field is Mandatory.");
    }
    return "";
}
function DropDownN(con, msg) {
    con.value = trim(con.value);
    return "";
}
/////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////Library
////////////////////////////////////////////////////////////
function trim(stringToTrim) { return stringToTrim.replace(/^\s+|\s+$/g, ""); }
function mandatoryDate(con) {
    if (con.value == "__-___-____") {
        con.value = "";
        return con.value;
    }
}
////////////////////////////////////////////////Contact Validationcon.value=trim(con.value);
function valcontact(con, msg) {
    if (con.value.length == 0) {
        return stringObject.concat(msg, " Field is Mandatory.");
    }
    if (!con.value.match(/^[+]\d{10,15}$|^\d{3,7}[\s,\-]\d{5,10}$|^\d{10,15}$/))
        return stringObject.concat(msg, " is not in correct format.");
    return "";
}
function valcontactN(con, msg) {
    if (con.value.length == 0) {
        return "";
    }
    if (!con.value.match(/^[+]\d{10,15}$|^\d{3,7}[\s,\-]\d{5,10}$|^\d{10,15}$/))
        return stringObject.concat(msg, " is not in correct format.");
    return "";
}
/////////////////////////////////////////Validate for special characters
function validateStr(con, msg) {
    var invalidChars = '\/\'\\";:?!()[]\{\}^|';
    for (i = 0; i < invalidChars.length; i++) {
        if (con.value.indexOf(invalidChars.charAt(i)) != -1) {
            return stringObject.concat(" Special Characters like / ' \" ; : ? ! ( ) etc are not allowed in ", msg, " .");
        }
    }
    return "";
}
///////////////////////////////////////////////
function validateYearField(con, msg)//2006-2007
{
    if (con.value.length == 0) {
        return stringObject.concat(msg, " Field is Mandatory.");
    }
    if (!con.value.match(/^\d{4}-\d{4}$/))
        return stringObject.concat(msg, " Is not in correct format(2008-2009).");
    return "";
}
/////////////////////////////////////////////////////////
function validateName(con, msg) {
    if (con.value.match(/(')|(")/))
        return stringObject.concat(msg, " Does not support special character ' \".");
    return "";
}

function validateYear(con, msg) {
    if (con.value.length == 0) {
        return stringObject.concat(msg, " Field is Mandatory.");
    }
    if (!con.value.match(/^\d{4}-\d{2}$|^\d{4}-\d{4}$/))
        return stringObject.concat(msg, " Is not in correct format(2008-09).");
    return "";
}
function validateYearFC(con, msg) {
    if (con.value.length == 0) {
        return stringObject.concat(msg, " Field is Mandatory.");
    }
    if (!con.value.match(/^\d{4}-\d{2}$|^\d{4}-\d{4}$|^\d{4}$/))
        return stringObject.concat(msg, " Is not in correct format(2008-09).");
    return "";
}
/////////////////////////////////////////////////////////
function validateTimeDuration(con, msg) {
    if (!con.value.match(/^((([0]?[0-5][0-9]|[0-9]):([0-5][0-9]))-(([0]?[0-5][0-9]|[0-9]):([0-5][0-9])),)*(([0]?[0-5][0-9]|[0-9]):([0-5][0-9]))-(([0]?[0-5][0-9]|[0-9]):([0-5][0-9]))$/))
        return stringObject.concat(msg, " Is not in correct format(mm:hh-mm:hh,mm:hh-mm:hh).");
    return "";
}
/////////////////////////////////////////////////////////
function validateYearN(con, msg) {
    if (!con.value.match(/^\d{4}-\d{2}$|^\d{4}-\d{4}$/))
        return stringObject.concat(msg, " Is not in correct format(2008-09).");
    return "";
}
/////////////////////////////////////////////////////////
function validateEmail(con, msg) {
    if (!con.value.match(/^([0-9a-zA-Z]+([_.-]?[0-9a-zA-Z]+)*@[0-9a-zA-Z]+[0-9,a-z,A-Z,.,-]*.{1}[a-zA-Z]{2,4})+$/))
        return stringObject.concat(msg, "Please enter a valid email ID.");
    return "";
}
function validateEmailN(con, msg) {
    if (msg1 != "") {
        if (!con.value.match(/^([0-9a-zA-Z]+([_.-]?[0-9a-zA-Z]+)*@[0-9a-zA-Z]+[0-9,a-z,A-Z,.,-]*.{1}[a-zA-Z]{2,4})+$/))
            return stringObject.concat(msg, " is not valid. Please enter a valid email ID.");
        return "";
    }
}
////////////////////////////////////////////////////////
function validateURL(con, msg) {
    var RegExp = /^(([\w]+:)?\/\/)?(([\d\w]|%[a-fA-f\d]{2,2})+(:([\d\w]|%[a-fA-f\d]{2,2})+)?@)?([\d\w][-\d\w]{0,253}[\d\w]\.)+[\w]{2,4}(:[\d]+)?(\/([-+_~.\d\w]|%[a-fA-f\d]{2,2})*)*(\?(&?([-+_~.\d\w]|%[a-fA-f\d]{2,2})=?)*)?(#([-+_~.\d\w]|%[a-fA-f\d]{2,2})*)?$/;
    if (con.value.match(RegExp)) {
        return "";
    } else {
        return stringObject.concat(msg, " is not valid. Please enter a valid URL.");
    }
}
////////////////////////////////////////////////////////
function validateURLB(con, msg) {
    if (!con.value.match(/^(([\w]+:)?\/\/)?(([\d\w]|%[a-fA-f\d]{2,2})+(:([\d\w]|%[a-fA-f\d]{2,2})+)?@)?([\d\w][-\d\w]{0,253}[\d\w]\.)+[\w]{2,4}(:[\d]+)?(\/([-+_~.\d\w]|%[a-fA-f\d]{2,2})*)*(\?(&?([-+_~.\d\w]|%[a-fA-f\d]{2,2})=?)*)?(#([-+_~.\d\w]|%[a-fA-f\d]{2,2})*)?$/))
        return stringObject.concat(msg, " is not valid. Please enter a valid URL.");
    return "";
}
////////////////////////////////////////////////////////
function validateURLN(con, msg) {
    var RegExp = /^(([\w]+:)?\/\/)?(([\d\w]|%[a-fA-f\d]{2,2})+(:([\d\w]|%[a-fA-f\d]{2,2})+)?@)?([\d\w][-\d\w]{0,253}[\d\w]\.)+[\w]{2,4}(:[\d]+)?(\/([-+_~.\d\w]|%[a-fA-f\d]{2,2})*)*(\?(&?([-+_~.\d\w]|%[a-fA-f\d]{2,2})=?)*)?(#([-+_~.\d\w]|%[a-fA-f\d]{2,2})*)?$/;
    if (con.value.match(RegExp)) {
        return "";
    } else {
        return stringObject.concat(msg, " Is not valid. Please enter a valid URL.");
    }
}
///////////////////////////////////////////////////length
function minlength(con, minlen, msg) {
    if (con.value.length < minlen) {
        return stringObject.concat(msg, " Must be Minimum of ", minlen, " Characters.");
    }
    return "";
}
function maxlength(con, maxlen, msg) {
    if (con.value.length > maxlen) {

        return stringObject.concat(msg, " Must be Maximum of ", maxlen, " Characters.");
    }
    return "";
}
function minmaxlength(con, minlen, maxlen, msg) {
    if (con.value.length < minlen) {
        return stringObject.concat(msg, " Must be Minimum of ", minlen, " Characters.");
    }
    if (con.value.length > maxlen) {
        return stringObject.concat(msg, " Must be Maximum of ", maxlen, " Characters.");
    }
    return "";
}
///////////////////////////////////////////////Min max value
function minmaxValue(con, min, max, msg) {
    if (con.value < min) {
        return stringObject.concat(msg, " Can not be less then ", min, ".");
    }
    if (con.value > max) {
        return stringObject.concat(msg, " Can not be Greater then ", max, ".");
    }
    return "";
}
////////////////////////////////////////////Numeric
function numeric(con, msg) {
    if (isNaN(con.value)) {
        return stringObject.concat(msg, " Must be Numeric.");
    }
    return "";
}
function decimal(con, msg) {
    if (!con.value.match(/^\d{1,20}$/)) {
        return stringObject.concat(msg, " Please enter a round off number. Do not enter decimal points and alphabets.");
    }
    return "";
}

function Acceptdecimal(con, msg) {
    if (con.value != "") {
        var Chars = "0123456789.";
        for (var i = 0; i < con.value.length; i++) {
            if (Chars.indexOf(con.value.charAt(i)) == -1) {
                return stringObject.concat(msg, " Field should be in amount format.");
            }
        }
    }
    return "";
}
//////////////////////////////////////////////////////////////
function ValidateDateN(con, msg) {
    if (con.value.length == 0) {
        return "";
    }
    var dt1 = parseInt(con.value.substring(0, 2), 10);
    var temp1 = con.value.substring(3, 6);
    msg1 = minmaxlength(con, 11, 11, msg);
    if (msg1 != "") return msg1;
    if (!getMonthvalue(temp1)) {
        return stringObject.concat(msg, " Is not a valid Date.");
    }
    var temp2 = con.value.substring(7, 11);
    if (!getYearvalue(temp2)) {
        return stringObject.concat(msg, " Is not a valid Date.");
    }
    return "";
}
function ValidateDate(con, msg) {
    if (mandatoryDate(con) == "")
        return stringObject.concat(msg, " Is Mandatory.");
    var dt1 = parseInt(con.value.substring(0, 2), 10);
    var temp1 = con.value.substring(3, 6);
    msg1 = minmaxlength(con, 11, 11, msg);
    if (msg1 != "") return msg1;
    if (!getMonthvalue(temp1)) {
        return stringObject.concat(msg, " Is not a valid Date.");
    }
    var temp2 = con.value.substring(7, 11);
    if (!getYearvalue(temp2)) {
        return stringObject.concat(msg, " Is not a valid Date.");
    }
    return "";
}
//////////////////////////////////////////////////////////////////
function ValidateDateMask(con, msg) {
    if (mandatoryDate(con) == "__-___-____")
        return stringObject.concat(msg, " Is Mandatory.");
    var dt1 = parseInt(con.value.substring(0, 2), 10);
    var temp1 = con.value.substring(3, 6);
    if (!getMonthvalue(temp1)) {
        return stringObject.concat(msg, " Is not a valid Date.");
    }
    var temp2 = con.value.substring(7, 11);
    if (!getYearvalue(temp2)) {
        return stringObject.concat(msg, " Is not a valid Date.");
    }
    return "";
}
function ValidateMonthYearInt(con, msg) {
    con.value = trim(con.value);
    if (con.value.length == 0) {
        return stringObject.concat(msg, " Is Mandatory.");
    }
    if (con.value.indexOf("-") == -1) {
        return stringObject.concat(msg, " Is not a valid Date.");
    }
    if (msg1 != "") return msg1;
    return "";
}


//function ValidateMonthYear(con,msg)
//{
//if(mandatoryDate(con)=="")
//         return stringObject.concat(msg, " Is Mandatory.");
//          var dt1  = parseInt(con.value.substring(0,3),7);
//         var temp1=con.value.substring(0,3);
//         if(!getMonthvalue(temp1)){
//             return stringObject.concat(msg, " Is not a valid Date.");
//             }
//          return "";
//}
function CompareDate(str1, str2, msg1, msg2) {
    if (mandatoryDate(str1) == "")
        return stringObject.concat(msg1, " Is Mandatory.");
    if (str2 == "") {
        if (mandatoryDate(str2) == "")
            return stringObject.concat(msg2, " Is mandatory.");
        var dt1 = parseInt(str1.value.substring(0, 2), 10);
        var temp1 = str1.value.substring(3, 6);
        if (!getMonthvalue(temp1)) {
            return stringObject.concat(msg1, " Is not a valid Date.");
        }
        var mon1 = parseInt(getMonthvalue(temp1), 10); // getMonthvalue(temp1.value);
        var yr1 = parseInt(str1.value.substring(7, 11), 10);
        var dt2 = parseInt(str2.value.substring(0, 2), 10);
        var temp2 = str2.value.substring(3, 6);
        if (!getMonthvalue(temp2)) {
            return stringObject.concat(msg2, " Is not a valid Date.");
        }
        var mon2 = parseInt(getMonthvalue(temp2), 10); // ;
        var yr2 = parseInt(str2.value.substring(7, 11), 10);
        var date1 = new Date(yr1, mon1, dt1);
        var date2 = new Date(yr2, mon2, dt2);
        if (date1 >= date2) {
            return stringObject.concat(msg1, " Must be lesser than the ", msg2, ".");
        }
    }
    return "";
}

function getYearvalue(str) {
    if (str.length == 0) {
        return false;
    }
    else if (str.length < 4) {
        return false;
    }
    else if (str.length > 4) {
        return false;
    }
    return true;
}


function getMonthvalue(str) {
    var str1 = str.toLowerCase();
    switch (str1) {
        case "jan": return 01;
        case "feb": return 02;
        case "mar": return 03;
        case "apr": return 04;
        case "may": return 05;
        case "jun": return 06;
        case "jul": return 07;
        case "aug": return 08;
        case "sep": return 09;
        case "oct": return 10;
        case "nov": return 11;
        case "dec": return 12;
        default:
            return false;
    }
}
///////////////////////////////////////////////////

///validate email
function validateEmail2(addr, man, db) {
    if (addr == '' && man) {
        if (db) alert('Email address is Mandatory');
        return false;
    }
    if (addr == '') return true;
    var invalidChars = '\/\'\\ ";:?!()[]\{\}^|';
    for (i = 0; i < invalidChars.length; i++) {
        if (addr.indexOf(invalidChars.charAt(i), 0) > -1) {
            if (db) alert('Email address contains invalid characters');
            return false;
        }
    }
    for (i = 0; i < addr.length; i++) {
        if (addr.charCodeAt(i) > 127) {
            if (db) alert("Email address contains non ascii characters.");
            return false;
        }
    }

    var atPos = addr.indexOf('@', 0);
    if (atPos == -1) {
        if (db) alert('Email address must contain an @');
        return false;
    }
    if (atPos == 0) {
        if (db) alert('Email address must not start with @');
        return false;
    }
    if (addr.indexOf('@', atPos + 1) > -1) {
        if (db) alert('Email address must contain only one @');
        return false;
    }
    if (addr.indexOf('.', atPos) == -1) {
        if (db) alert('Email address must contain a period in the domain name');
        return false;
    }
    if (addr.indexOf('@.', 0) != -1) {
        if (db) alert('Period must not immediately follow @ in email address');
        return false;
    }
    if (addr.indexOf('.@', 0) != -1) {
        if (db) alert('Period must not immediately precede @ in email address');
        return false;
    }
    if (addr.indexOf('..', 0) != -1) {
        if (db) alert('Two periods must not be adjacent in email address');
        return false;
    }
    var suffix = addr.substring(addr.lastIndexOf('.') + 1);
    if (suffix.length != 2 && suffix != 'com' && suffix != 'net' && suffix != 'org' && suffix != 'edu' && suffix != 'int' && suffix != 'mil' && suffix != 'gov' & suffix != 'arpa' && suffix != 'biz' && suffix != 'aero' && suffix != 'name' && suffix != 'coop' && suffix != 'info' && suffix != 'pro' && suffix != 'museum') {
        if (db) alert('Invalid primary domain in email address');
        return false;
    }
    return true;
}




function validateEmailNotMan(addr, man, db) {
    //if (addr == '' && man) {
    //   if (db) alert('Email address is Mandatory');
    //   return false;
    //}
    //if (addr == '') return true;
    var invalidChars = '\/\'\\ ";:?!()[]\{\}^|';
    for (i = 0; i < invalidChars.length; i++) {
        if (addr.indexOf(invalidChars.charAt(i), 0) > -1) {
            if (db) alert('Email address contains invalid characters');
            return false;
        }
    }
    for (i = 0; i < addr.length; i++) {
        if (addr.charCodeAt(i) > 127) {
            if (db) alert("Email address contains non ascii characters.");
            return false;
        }
    }

    var atPos = addr.indexOf('@', 0);
    if (atPos == -1) {
        if (db) alert('Email address must contain an @');
        return false;
    }
    if (atPos == 0) {
        if (db) alert('Email address must not start with @');
        return false;
    }
    if (addr.indexOf('@', atPos + 1) > -1) {
        if (db) alert('Email address must contain only one @');
        return false;
    }
    if (addr.indexOf('.', atPos) == -1) {
        if (db) alert('Email address must contain a period in the domain name');
        return false;
    }
    if (addr.indexOf('@.', 0) != -1) {
        if (db) alert('Period must not immediately follow @ in email address');
        return false;
    }
    if (addr.indexOf('.@', 0) != -1) {
        if (db) alert('Period must not immediately precede @ in email address');
        return false;
    }
    if (addr.indexOf('..', 0) != -1) {
        if (db) alert('Two periods must not be adjacent in email address');
        return false;
    }
    var suffix = addr.substring(addr.lastIndexOf('.') + 1);
    if (suffix.length != 2 && suffix != 'com' && suffix != 'net' && suffix != 'org' && suffix != 'edu' && suffix != 'int' && suffix != 'mil' && suffix != 'gov' & suffix != 'arpa' && suffix != 'biz' && suffix != 'aero' && suffix != 'name' && suffix != 'coop' && suffix != 'info' && suffix != 'pro' && suffix != 'museum') {
        if (db) alert('Invalid primary domain in email address');
        return false;
    }
    return true;
}
/////////////////////////////////////////////////////SentenceValidation
function valStr(con) {
    if (con.value.indexOf(" ") != -1) {
        return false;
    }
    return true;
}
var con1
function CompareCRDR(con, con1, msg) {
    if (parseInt(con.value) > 0 && parseInt(con1.value) > 0) {
        return stringObject.concat(msg, "");
    }
    return "";
}

function Batch100(con, msg) {
    con.value = trim(con.value);
    if (con.value.length == 0) {
        return stringObject.concat(msg, " Field is Mandatory.");
    }
    return "";
}

function CompareStk(con, msg) {
    if (con.value == 'Stock Is Empty') {
        return stringObject.concat(msg, ".");
    }
    return "";
}
//////////////////////////comb
function GlbShowSImage(con) {
    con.style.backgroundImage = 'url(images/Gwheel.gif)';

    con.style.backgroundRepeat = 'no-repeat';

    con.style.backgroundPosition = 'right';
    con.style.color = 'Blue'
    setTimeout(function() { GlbHideSImage(con); }, 2000);
}
function GlbHideSImage(con) {
    con.style.backgroundImage = 'none';
}
function NameField100E(con, msg) {
    con.value = trim(con.value);
    if (con.value.length == 0) {
        return stringObject.concat(msg, " Field is Mandatory.");
    }
    msg1 = minmaxlength(con, 2, 100, msg);
    if (msg1 != "") return msg1;
    return "";
}
function NameField100NE(con, msg) {
    con.value = trim(con.value);
    if (con.value.length != 0)
        msg1 = minmaxlength(con, 2, 100, msg);
    if (msg1 != "") return msg1;
    return "";
}
function NameField250E(con, msg) {
    con.value = trim(con.value);
    if (con.value.length == 0) {
        return stringObject.concat(msg, " Field is Mandatory.");
    }
    msg1 = minmaxlength(con, 2, 250, msg);
    if (msg1 != "") return msg1;
    return "";
}
function NameField250NE(con, msg) {
    con.value = trim(con.value);
    if (con.value.length != 0)
        msg1 = minmaxlength(con, 2, 250, msg);
    if (msg1 != "") return msg1;
    return "";
}

///////////////////////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////Validation For Multilingual Using Error Codes///////////////////////////////////
/////////////////////////////////Written By Ajit///////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////
function NameField100Mul(con) {
    con.value = trim(con.value);
    if (con.value.length == 0) { return 1000; }
    else if (con.value.length < 2) { return 1005; }
    else if (con.value.length > 100) { return 1006; }
    return "";
}
function NameField100NMul(con) {
    con.value = trim(con.value);
    if (con.value.length != 0) {
        if (con.value.length < 2) { return 1005; }
        else if (con.value.length > 100) { return 1006; }
        return "";
    }
    return "";
}
function NameField100NMulListBox(con) {
    con.value = trim(con.value);
    if (con.value.length == 0) {
       
        return "";
    }
    return "";
}

function Field30NMul(con) {
    con.value = trim(con.value);
    if (con.value.length != 0) {
        if (con.value.length < 2) { return 1005; }
        else if (con.value.length > 30) { return 1007; }
        return "";
    }
    return "";
    
    }
    

function Field50NMul(con, msg) {
    con.value = trim(con.value);
    if (con.value.length != 0) {
        if (con.value.length < 2) { return 1005; }
        else if (con.value.length > 50) { return 1008; }
        return "";
    }
    return "";
}

function Field255NMul(con, msg) {
    con.value = trim(con.value);
    if (con.value.length != 0) {
        if (con.value.length < 2) { return 1005; }
        else if (con.value.length > 255) { return 1009; }
        return "";
    }
    return "";
}
/////////////////////////To validate Postal Code Field//////////////////////
function PostalCodeMul(con, msg) {
    con.value = trim(con.value);
    if (con.value.length == 0) { return 1000; }
    else if (isNaN(con.value)) { return 1010; }
    else if (con.value.length < 6) { return 1011; }
    else if (con.value.length > 6) { return 1012; }
    return "";
}

function PostalCodeNMul(con, msg) {
if (con.value.length == 0) { return ""; }
    else if (isNaN(con.value)) { return 1010; }
    else if (con.value.length < 6) { return 1071; }
    else if (con.value.length > 6) { return 1072; }
    return "";
}
/////////////////////////To validate Fees Field//////////////////////             
function FeesFieldMul(con) {
    con.value = trim(con.value);
    if (con.value < 0) { return 1000; }
    else if (isNaN(con.value)) { return 1010; }
    else if (con.value.length < 1) { return 1011; }
    else if (con.value.length > 10) { return 1012; }
    return "";
}

function FeesFieldNMul(con) {
    con.value = trim(con.value);
    if (con.value.length != 0) {
        if (isNaN(con.value)) { return 1010; }
        else if (con.value.length < 1) { return 1011; }
        else if (con.value.length > 10) { return 1012; }
        return "";
    }
    return "";
}

/////////////////////////To validate Fees Field which can accept decimal//////////////////////
function FeesFieldAcceptDecimalMul(con) {
    con.value = trim(con.value);
    if (con.value == 0) { return 1000; }
    if (con.value != "") {
        var Chars = "0123456789.";
        for (var i = 0; i < con.value.length; i++) {
            if (Chars.indexOf(con.value.charAt(i)) == -1) { return 1069; }
        }
    }
    if (con.value.length < 1) { return 1011; }
    else if (con.value.length > 20) { return 1070; }
    return 1014;
}

//function FeesFieldAcceptDecimalNMul(con) {
//    con.value = trim(con.value);
//    msg1 = Acceptdecimal(con);
//    if (msg1 != "") return msg1;
//    if (con.value != "") {
//        var Chars = "0123456789.";
//        for (var i = 0; i < con.value.length; i++) {
//            if (Chars.indexOf(con.value.charAt(i)) == -1) { return 1069; }
//        }
//    }
//    if (con.value.length == 0) { return ""; }
//    else if (con.value.length < 1) { return 1011; }
//    else if (con.value.length > 20) { return 1070; }
//    return 1014;
//}
function FeesFieldAcceptDecimalNMul(con) {
    con.value = trim(con.value);
    msg1 = AcceptdecimalMul(con);
    if (msg1 != "") return msg1;
    if (con.value.length != 0)
        msg1 = minmaxlengthMul(con, 1, 10);
    if (msg1 != "") return msg1;
    return "";
}

function AcceptdecimalMul(con) {
    if (con.value != "") {
        var Chars = "0123456789.";
        for (var i = 0; i < con.value.length; i++) {
            if (Chars.indexOf(con.value.charAt(i)) == -1) {
                return 1069;
            }
        }
    }
    return "";
}
/////////////////////////To validate Dropdown selected or not//////////////////////   
function DropDownMul(con, msg) {
    con.value = trim(con.value);
    if (con.value == "0") {
        return 1000;
    }
    if (con.value.match(/^Select$/)) {
        return 1000;
    }
    return "";
}
function DropDownMulNoSub(con) {
    con.value = trim(con.value);
    if (con.value == "99") {
        return 1000;
    }
    if (con.value.match(/^99$/)) {
        return 1000;
    }
    return "";
}

////////////////////////////Written by Niraj on 24-oct-2013////////////////////////////////
function DropDownNMul(con, msg) {
    con.value = trim(con.value);
    return "";
}
///////////////////////////////////////////
function DropDownForZeroMul(con) {
    con.value = trim(con.value);
    if (con.value == "0") {
        return 1000;
    }
    if (con.value.match(/^0$/)) {
        return 1000;
    }
    return "";
}

/////////////////////////////////////////////////////////
function validateNameMul(con, msg) {
    con.value = trim(con.value);
    if (con.value.length == 0) { return 1000; }
    if (con.value.match(/(')|(")/))
        return 1001;
    return "";
}
/////////////////////////////////////////////////////////
function validateEmailMul(con) {
    if (!con.value.match(/^([0-9a-zA-Z]+([_.-]?[0-9a-zA-Z]+)*@[0-9a-zA-Z]+[0-9,a-z,A-Z,.,-]*.{1}[a-zA-Z]{2,4})+$/))
        return 1002;
    return "";
}
function validateEmailNMul(con, msg) {
    if (msg1 != "") {
        if (!con.value.match(/^([0-9a-zA-Z]+([_.-]?[0-9a-zA-Z]+)*@[0-9a-zA-Z]+[0-9,a-z,A-Z,.,-]*.{1}[a-zA-Z]{2,4})+$/))
            return 1003;
        return "";
    }
}

///////////////////////////////////////////////////length
function minlengthMul(con, len) {
    con.value = trim(con.value);
    if (con.value.length == 0) {
        return 1000;
    }
    if (con.value.length < len) {
        if (minlen = 1) { return 1004; }
    }
    return "";

}

function NameField100E(con) {
    con.value = trim(con.value);
    if (con.value.length == 0) {
        return 1000;
    }
    msg1 = minmaxlength(con, 2, 100);
    if (msg1 != "") return msg1;
    return "";
}

////////////////Validation for AgeField///////////////////////////////////////////////////////////////////////////////////////////////

function AgeFieldMul(con, msg) {
    con.value = trim(con.value);
    if (con.value.length == 0) {
        return 1000;
    }
    else if (isNaN(con.value)) { return 1010; }
    else if (con.value.length < 0) { return 1032; }
    else if (con.value.length > 3) { return 1033; }
    return "";
}
function AgeFieldMulN(con, msg) {
    con.value = trim(con.value);
    if (isNaN(con.value)) { return 1010; }
    else if (con.value.length < 0) { return 1032; }
    else if (con.value.length > 3) { return 1033; }
    return "";
}

///////////////////////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////Validation For Multilingual Using Error Codes///////////////////////////////////
/////////////////////////////////Written By Niraj///////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////


function NameField250Mul(con) {
    con.value = trim(con.value);
    if (con.value.length == 0) { return 1000; }
    else if (con.value.length < 2) { return 1005; }
    else if (con.value.length > 250) { return 1039; }
    return "";
}
function Field255NMul(con, msg) {
    con.value = trim(con.value);
    if (con.value.length != 0) {
        if (con.value.length < 2) { return 1005; }
        else if (con.value.length > 255) { return 1009; }
        return "";
    }
    return "";
}

////////////////Validation for CodeField///////////////////////////////////////////////////////////////////////////////////////////////

function CodeFieldMul(con) {
    con.value = trim(con.value);
    if (con.value.length == 0) {
        return 1000;
    }
    var msg1 = minmaxlength(con, 2, 15);
    if (msg1 != "") return msg1;
    msg1 = validateStrMul(con);
    if (msg1 != "") return msg1;
    return "";
}
////////////////Validation for Validate String///////////////////////////////////////////////////////////////////////////////////////////////
function validateStrMul(con) {
    var invalidChars = '\/\'\\";:?!()[]\{\}^|';
    for (i = 0; i < invalidChars.length; i++) {
        if (con.value.indexOf(invalidChars.charAt(i)) != -1) {
            return 1040;
        }
    }
    return "";
}

function minmaxlengthMul(con, minlen, maxlen) {
    if (con.value.length < minlen) {
        return 1065;
    }
    if (con.value.length > maxlen) {
        return 1066;
    }
    return "";
}
function minmaxlengthMulMobNo(con, minlen, maxlen) {
    if (con.value.length < minlen) {
        return 1223;
    }
    if (con.value.length > maxlen) {
        return 1224;
    }
    return "";
}

////////////////Validation for Date with Mandatory///////////////////////////////////////////////////////////////////////////////////////////////
function ValidateDateMul(con) {
    if (mandatoryDate(con) == "")
        return 1000;
    var dt1 = parseInt(con.value.substring(0, 2), 10);
    var temp1 = con.value.substring(3, 6);
    var msg1 = minmaxlengthMul(con, 11, 11);
    if (msg1 != "") return msg1;
    if (!getMonthvalue(temp1)) {
        return 1067;
    }
    var temp2 = con.value.substring(7, 11);
    if (!getYearvalue(temp2)) {
        return 1067;
    }
    return "";
}
/////////////////Created By Ajit////////////////////
////////////////Validation for CodeField///////////Date--9th Aug 2013//////////////////////////////////////////////////////
function CodeFieldMul(con) {
    con.value = trim(con.value);
    if (con.value.length == 0) {
        return 1000;
    }
    if (con.value.length < 2) { return 1035; }
    else if (con.value.length > 15) { return 1036; }
    var invalidChars = '\/\'\\";:?!()[]\{\}^|';
    for (i = 0; i < invalidChars.length; i++) {
        if (con.value.indexOf(invalidChars.charAt(i)) != -1) {
            return 1040;
        }
    }


    return "";
}


function CodeFieldNMul(con) {
    con.value = trim(con.value);
    if (con.value.length < 2) { return 1035; }
    else if (con.value.length > 15) { return 1036; }
    var invalidChars = '\/\'\\";:?!()[]\{\}^|';
    for (i = 0; i < invalidChars.length; i++) {
        if (con.value.indexOf(invalidChars.charAt(i)) != -1) {
            return 1040;
        }
    }

    return "";
}

////////////////Validation for OneChar/////////////////////////////////////////////////////////////////

function Field50Mul(con) {
    con.value = trim(con.value);
    if (con.value.length == 0) { return 1000; }
    else if (con.value.length < 2) { return 1005; }
    else if (con.value.length > 50) { return 1008; }
    return "";
}

function Field250Mul(con) {
    con.value = trim(con.value);
    if (con.value.length == 0) { return 1000; }
    else if (con.value.length < 2) { return 1005; }
    else if (con.value.length > 250) { return 1057; }
    return "";
}

function Field250MulN(con) {
    con.value = trim(con.value);
    if (con.value.length == 0) { return ""; }
    else if (con.value.length < 2) { return 1005; }
    else if (con.value.length > 250) { return 1057; }
    return "";
}

function OneCharMul(con) {
    con.value = trim(con.value);
    if (con.value.length == 0) { return 1000; }
    else if (con.value.length < 1) { return 1004; }
    else if (con.value.length > 50) { return 1008; }
    if (con.value.match(/(')|(")/))
    { return 1001; }
    return "";
}

////////////////Validation for numeric/////////////////////////////////////////////////////////////////

function numericMul(con) {
    if (isNaN(con.value)) {
        return 1010;
    }
    return "";
}

////////////////////////////////////////////////Contact Validationcon.value=trim(con.value);
function valcontactMul(con) {
    if (con.value.length == 0) {
        return 1000;
    }
    if (!con.value.match(/^[+]\d{10,15}$|^\d{3,7}[\s,\-]\d{5,10}$|^\d{10,15}$/))
        return 1073;
    return "";
}
function valcontactNMul(con, msg) {
    if (con.value.length == 0) {
        return "";
    }
    if (!con.value.match(/^[+]\d{10,15}$|^\d{3,7}[\s,\-]\d{5,10}$|^\d{10,15}$/))
        return 1073;
    return "";
}
//////////////////////////////Validation for Date with Non Mandatory by:Niraj\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

function ValidateDateMulN(con) {
    if (con.value.length == 0) {
        return "";
    }
    var dt1 = parseInt(con.value.substring(0, 2), 10);
    var temp1 = con.value.substring(3, 6);
    var msg1 = minmaxlengthMul(con, 11, 11);
    if (msg1 != "") return msg1;
    if (!getMonthvalue(temp1)) {
        return 1067;
    }
    var temp2 = con.value.substring(7, 11);
    if (!getYearvalue(temp2)) {
        return 1067;
    }
    return "";

}

function FieldNumMul(con, msg) {
    con.value = trim(con.value);
    if (con.value.length == 0) {
        return 1000;
    }
    if (isNaN(con.value)) { return 1010; }
    else if (con.value.length < 0) { return 1032; }
    else if (con.value.length > 6) { return 1078; }
    return "";
}
/////////////////////////////////////////////// FeesFieldRestrictDecimal Written by Niraj/////////////////////////
function FeesFieldRestrictDecimalMul(con,msg) {
    con.value = trim(con.value);
    if (con.value == 0) {
        return 1000;
    }
    msg1 = numericMul(con, msg);
    if (msg1 != "") return msg1;
    msg1 = decimalMul(con, msg);
    if (msg1 != "") return msg1;
    msg1 = minmaxlengthMul(con, 1, 10, msg);
    if (msg1 != "") return msg1;
    return "";
}
function decimalMul(con, msg) {
    if (!con.value.match(/^\d{1,20}$/)) {
        return 1138;
    }
    return "";
}

////////////////////////////////AutoCompleteExtenderForThree Multilingual Function written By: Niraj////////////////14-Nov-2013////

function AutoCompleteExtenderForThreeMul(con, msg) {
    msg1 = ""
    con.value = trim(con.value);
    if (con.value.length == 0) {
        return 1000;
    }
    if (con.value == "Type first 3 characters") {
        return 1000;
    }
    if (msg1 != "") return msg1;
    return "";
}

//////////////////////////////////////////Mob No validation////////////////////////////////////////////
function MobFieldMul(con, msg) {
    con.value = trim(con.value);
    if (con.value.length == 0) {
        return 1000;
    }
    msg1 = minmaxlengthMulMobNo(con, 10, 20, msg);
    if (msg1 != "") return msg1;
    msg1 = minmaxlengthMulMobNo(con, msg);
    if (msg1 != "") return msg1;
    return "";
}
function MobFieldNMul(con, msg) {
    con.value = trim(con.value);
    if (con.value.length != 0)
        msg1 = minmaxlengthMulMobNo(con, 10, 20, msg);
    if (msg1 != "") return msg1;
    msg1 = validateNameMul(con, msg);
    if (msg1 != "") return msg1;
    return "";
}
/////////////////////////////////////////////////Password Validation///////////////////////////////////
function passCheck(con, str) {
    var password = con.value;
    var msg = "<ul style='color:red;'>" + str + " :";
    var errorCount = 0;
    if (password.length < 5 && password.length > 15) {
        msg = str + "<li> must atleast be 6 characters long and not more than 15 characters long.</li>";
        errorCount += 1;
    }
    if (!password.match(/^(?=.*[a-z])(?=.*[A-Z])/)) {
        msg += "<li> must contain atleast 1 upper case and 1 lower case alphabet.</li>";
        errorCount += 1;
    }
    if (!password.match(/([0-9])/)) {
        msg += "<li> must contain atleast 1 digit.</li>";
        errorCount += 1;
    }
    if (!password.match(/(?=.*[!@#$%^&*])/)) {
        msg += "<li> must contain atleast 1 special character.</li>";
        errorCount += 1;
    }
    if (password.match(/(['";])/)) {
        msg += "<li> must <b>not</b> contain ' (Apostrophe) , \" (double qoutes), ; (semi colon).</li>";
        errorCount += 1;
    }
    if(errorCount > 0)
        return msg + "</ul>";
    else
        return true;
}