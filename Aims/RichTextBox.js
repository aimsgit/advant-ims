
var	isHTMLMode=false;

function setDesignMode(childId)
{
	var RichTextFrame = childId.concat('_RichTextFrame');
	document.frames[RichTextFrame].document.designMode = 'on';
}

function textCommand(command,childId,opt) 
{
	if (isHTMLMode)
	{
		alert("Formatting happens only in Normal mode");
		return;
	}
	var RichTextFrame = childId.concat('_RichTextFrame');
	
	document.frames[RichTextFrame].focus();
	
	document.frames[RichTextFrame].document.execCommand(command,"",opt);
	
	document.frames[RichTextFrame].focus();
}

function WordCount(childId)
{
	var countTextBox = childId + '_TxtCount';
	
	var count = window.parent.document.getElementById(countTextBox).value;
	
	var RichTextFrame = childId.concat('_RichTextFrame');
	
	var textEntered = document.frames[RichTextFrame].document.body.innerText;
			
	window.parent.document.getElementById(countTextBox).value = textEntered.length;
}

function fillTxtId(childId)
{
	
	var HTMLText = childId.concat('_HTMLText');
	var TextValue = childId.concat('_TextValue');
	var RichTextFrame = childId.concat('_RichTextFrame');
	document.getElementById(HTMLText).value = document.frames[RichTextFrame].document.body.innerHTML;
	document.getElementById(TextValue).value = document.frames[RichTextFrame].document.body.innerText;	
}

function ChangeFontSize(childId)
{

	var RichTextFrame = childId.concat('_RichTextFrame');
	
	document.frames[RichTextFrame].focus();
	
	document.frames[RichTextFrame].document.execCommand('FontSize',0,fontSize.options[fontSize.selectedIndex].value);
	
	document.frames[RichTextFrame].focus();							
		
}
