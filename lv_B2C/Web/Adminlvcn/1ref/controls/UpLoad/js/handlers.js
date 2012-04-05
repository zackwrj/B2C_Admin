function fileQueueError(file, errorCode, message) {
//	try {
//		var imageName = "error.gif";
//		var errorName = "";
//		if (errorCode === SWFUpload.errorCode_QUEUE_LIMIT_EXCEEDED) {
//			errorName = "You have attempted to queue too many files.";
//		}

//		if (errorName !== "") {
//			alert(errorName);
//			return;
//		}

//		switch (errorCode) {
//		case SWFUpload.QUEUE_ERROR.ZERO_BYTE_FILE:
//			imageName = "zerobyte.gif";
//			break;
//		case SWFUpload.QUEUE_ERROR.FILE_EXCEEDS_SIZE_LIMIT:
//			imageName = "toobig.gif";
//			break;
//		case SWFUpload.QUEUE_ERROR.ZERO_BYTE_FILE:
//		case SWFUpload.QUEUE_ERROR.INVALID_FILETYPE:
//		default:
//			alert(message);
//			break;
//		}

//		addImage("images/" + imageName);

//	} catch (ex) {
//		this.debug(ex);
    //	}
    try {
        if (errorCode === SWFUpload.QUEUE_ERROR.QUEUE_LIMIT_EXCEEDED) {
            alert("ѡ���ļ����������ƣ�\n" + (message === 0 ? "�ϴ��ļ���������." : "ÿ���������ϴ�" + (message > 1 ? message + " " : "1��.")));
            return;
        }

        var progress = new FileProgress(file, this.customSettings.progressTarget);
        progress.setError();
        progress.toggleCancel(false);

        switch (errorCode) {
            case SWFUpload.QUEUE_ERROR.FILE_EXCEEDS_SIZE_LIMIT:
                progress.setStatus("�������ļ��������.");
                this.debug("��ʾ: �ļ�̫��, �ļ���: " + file.name + ", �ļ���С: " + file.size + ", ��Ϣ: " + message);
                break;
            case SWFUpload.QUEUE_ERROR.ZERO_BYTE_FILE:
                progress.setStatus("�����ϴ�0Byte�ļ�.");
                this.debug("��ʾ: 0Byte�ļ�, �ļ���: " + file.name + ", �ļ���С: " + file.size + ", ��Ϣ: " + message);
                break;
            case SWFUpload.QUEUE_ERROR.INVALID_FILETYPE:
                progress.setStatus("��������ļ�����");
                this.debug("��ʾ: �������ϴ��������ļ�, �ļ���: " + file.name + ", �ļ���С: " + file.size + ", ��Ϣ: " + message);
                break;
            default:
                if (file !== null) {
                    progress.setStatus("δ֪����");
                }
                this.debug("��ʾ: " + errorCode + ", �ļ���: " + file.name + ", �ļ���С: " + file.size + ", ��Ϣ: " + message);
                break;
        }
    } catch (ex) {
        this.debug(ex);
    }

}

function fileDialogComplete(numFilesSelected, numFilesQueued) {
	try {
		if (numFilesQueued > 0) {
			this.startUpload();
		}
	} catch (ex) {
		this.debug(ex);
	}
}

function uploadProgress(file, bytesLoaded) {

	try {
		var percent = Math.ceil((bytesLoaded / file.size) * 100);

		var progress = new FileProgress(file,  this.customSettings.upload_target);
		progress.setProgress(percent);
		if (percent === 100) {
			progress.setStatus("׼��...");
			progress.toggleCancel(false, this);
		} else {
			progress.setStatus("�ϴ���...");
			progress.toggleCancel(true, this);
		}
	} catch (ex) {
		this.debug(ex);
	}
}

function uploadSuccess(file, serverData) {
	try {
	    //addImage("thumbnail.aspx?id=" + serverData);
	    addImage("/Adminlvcn/1ref/controls/UpLoad/UpLoad/Show.ashx?id=" + serverData,file);
		var progress = new FileProgress(file,  this.customSettings.upload_target);
		progress.setComplete();
		progress.setStatus("�ϴ����.");
		progress.toggleCancel(false);


	} catch (ex) {
		this.debug(ex);
	}
}

function uploadComplete(file) {
	try {
		/*  I want the next upload to continue automatically so I'll call startUpload here */
		if (this.getStats().files_queued > 0) {
			this.startUpload();
		} else {
			var progress = new FileProgress(file,  this.customSettings.upload_target);
			progress.setComplete();
			progress.setStatus("All images received.");
			progress.toggleCancel(false);
		}
	} catch (ex) {
		this.debug(ex);
	}
}

function uploadError(file, errorCode, message) {
	var imageName =  "error.gif";
	var progress;
	try {
		switch (errorCode) {
		case SWFUpload.UPLOAD_ERROR.FILE_CANCELLED:
			try {
				progress = new FileProgress(file,  this.customSettings.upload_target);
				progress.setCancelled();
				progress.setStatus("Cancelled");
				progress.toggleCancel(false);
			}
			catch (ex1) {
				this.debug(ex1);
			}
			break;
		case SWFUpload.UPLOAD_ERROR.UPLOAD_STOPPED:
			try {
				progress = new FileProgress(file,  this.customSettings.upload_target);
				progress.setCancelled();
				progress.setStatus("Stopped");
				progress.toggleCancel(true);
			}
			catch (ex2) {
				this.debug(ex2);
			}
		case SWFUpload.UPLOAD_ERROR.UPLOAD_LIMIT_EXCEEDED:
			imageName = "uploadlimit.gif";
			break;
		default:
			alert(message);
			break;
		}

		addImage("images/" + imageName);

	} catch (ex3) {
		this.debug(ex3);
	}

}


function addImage(src,file) {
    var newImg = document.createElement("img");
    newImg.style.margin = "5px";

    //����Ԫ��
    var $UploadDiv = $("<div class='UploadDiv'></div>"); //����
    var $UploadImage = $("<div class='UploadImage'></div>"); //ͼƬ����
    var $UploadTop = $("<div class='UploadTop'></div>");  //����
    var $UploadTopSpanLeft = $("<span class='l'></span>");
    var $UploadTopImageCheck = $("<img src='/Adminlvcn/1ref/controls/UpLoad/Images/check.png' alt='ѡ��' />");
    var $UploadTopSpanRight = $("<span class='r'></span>"); ;
    var $UploadTopImageClose = $("<img src='/Adminlvcn/1ref/controls/UpLoad/Images/close.png' alt='ɾ��' />");
    var $Upload = $("<div class='Upload'></div>") //ͼƬ
    var $UploadImg;
    var $UploadTitle = $("<div class='UploadTitle'></div>"); //����
    var $UploadTitleSpan = $("<span>" + file.name.substr(0, file.name.length - 4) + "</span>");

    //����
    $UploadDiv.attr("id", GetImagesID(src)); //cannel
    $UploadDiv.attr("check", "0");
    $UploadTopImageClose.attr("id", "editCannelButton_" + GetImagesID(src));
    $UploadTopImageCheck.css("visibility", "hidden");
    $UploadTopImageClose.css("visibility", "hidden");
    $UploadTitle.attr("id", "editTitle_" + GetImagesID(src));

    //���
    $UploadTopSpanLeft.append($UploadTopImageCheck);
    $UploadTopSpanRight.append($UploadTopImageClose);
    $UploadTop.append($UploadTopSpanLeft);
    $UploadTop.append($UploadTopSpanRight);
    $Upload.append($(newImg));
    $UploadImage.append($UploadTop);
    $UploadImage.append($Upload);
    $UploadTitle.append($UploadTitleSpan);
    $UploadDiv.append($UploadImage);
    $UploadDiv.append($UploadTitle);

    //�¼�
    $UploadImage.hover(function () {
        $UploadTopImageClose.css("visibility", "visible");
        $UploadImage.addClass("UploadImageHover");
    }, function () {
        $UploadTopImageClose.css("visibility", "hidden");
        $UploadImage.removeClass("UploadImageHover");
    }).click(function () {
        var thDivCount = $("#thumbnails .UploadDiv").length;
        var thDivCountCheck = $("#thumbnails .UploadDiv[check='1']").length + 1;
        var thDivCountCheckNot = $("#thumbnails .UploadDiv[check='0']").length + 1;
        if ($UploadDiv.attr("check") == "0") {
            $UploadTopImageCheck.css("visibility", "visible");
            $UploadDiv.attr("check", "1");
            if (thDivCount == thDivCountCheck) {
                //$("#checkAll").addClass("checked");
                //alert(thDivCountCheck + "gg" + thDivCount);
                $("label").trigger("click");
            }
        }
        else {
            $UploadTopImageCheck.css("visibility", "hidden");
            $UploadDiv.attr("check", "0");
            if (thDivCount >thDivCountCheck-2) {
                $("label").trigger("click");
            }
        }
    })

    $UploadTopImageClose.click(function () {
        $.get("/Adminlvcn/1ref/controls/UpLoad/UpLoad/Edit.ashx?edit=" + $UploadTopImageClose.attr("id"), function (d) {
            $UploadDiv.empty().remove();
        })
    })
    $UploadTitle.click(function () {
        var $temp = $("<span><input type='text'></span>");
        if ($UploadTitle.find("span input").length < 1) {
            $temp.find("input").bind("blur", function () {
                var $temps = $UploadTitle.find("span").find("input[type='text']").val();
                $.get("/Adminlvcn/1ref/controls/UpLoad/UpLoad/Edit.ashx?edit=editTitle_" + $UploadDiv.attr("id") + "&title=" + $temps, function (d) {
                    if ($temps == "") {
                        $temps = "����";
                    }
                    $UploadTitle.find("span").remove();
                    $UploadTitle.append("<span>" + $temps + "</span>");
                    //alert(d)
                    //$("#aa").append(d+"<br>");
                })
            })
            var ss = $UploadTitle.find("span").text();
            $temp.find("input").val(ss);
            $UploadTitle.find("span").remove();
            $UploadTitle.append($temp);
            $temp.find("input").select().focus();
            //setFocus($temp.find("input")[0]);
        }
    })



    //document.getElementById("thumbnails").appendChild(newImg);
    document.getElementById("thumbnails").appendChild($UploadDiv[0]);
    if (newImg.filters) {
        try {
            newImg.filters.item("DXImageTransform.Microsoft.Alpha").opacity = 0;
        } catch (e) {
            // If it is not set initially, the browser will throw an error.  This will set it if it is not set yet.
            newImg.style.filter = 'progid:DXImageTransform.Microsoft.Alpha(opacity=' + 0 + ')';
        }
    } else {
        newImg.style.opacity = 0;
    }
    newImg.onload = function () {
        fadeIn(newImg, 0);
    };
    newImg.src = src;
}

function fadeIn(element, opacity) {
	var reduceOpacityBy = 5;
	var rate = 10;	// 15 fps

	if (opacity < 100) {
		opacity += reduceOpacityBy;
		if (opacity > 100) {
			opacity = 100;
		}

		if (element.filters) {
			try {
				element.filters.item("DXImageTransform.Microsoft.Alpha").opacity = opacity;
			} catch (e) {
				// If it is not set initially, the browser will throw an error.  This will set it if it is not set yet.
				element.style.filter = 'progid:DXImageTransform.Microsoft.Alpha(opacity=' + opacity + ')';
			}
		} else {
			element.style.opacity = opacity / 100;
		}
	}

	if (opacity < 100) {
		setTimeout(function () {
			fadeIn(element, opacity);
		}, rate);
	}
}

function GetImagesID(src) {
    return src.substring(src.indexOf("=")+1);
}


/* ******************************************
 *	FileProgress Object
 *	Control object for displaying file info
 * ****************************************** */

function FileProgress(file, targetID) {
	this.fileProgressID = "divFileProgress";

	this.fileProgressWrapper = document.getElementById(this.fileProgressID);
	if (!this.fileProgressWrapper) {
		this.fileProgressWrapper = document.createElement("div");
		this.fileProgressWrapper.className = "progressWrapper";
		this.fileProgressWrapper.id = this.fileProgressID;

		this.fileProgressElement = document.createElement("div");
		this.fileProgressElement.className = "progressContainer";

		var progressCancel = document.createElement("a");
		progressCancel.className = "progressCancel";
		progressCancel.href = "#";
		progressCancel.style.visibility = "hidden";
		progressCancel.appendChild(document.createTextNode(" "));

		var progressText = document.createElement("div");
		progressText.className = "progressName";
		progressText.appendChild(document.createTextNode(file.name));

		var progressBar = document.createElement("div");
		progressBar.className = "progressBarInProgress";

		var progressStatus = document.createElement("div");
		progressStatus.className = "progressBarStatus";
		progressStatus.innerHTML = "&nbsp;";

		this.fileProgressElement.appendChild(progressCancel);
		this.fileProgressElement.appendChild(progressText);
		this.fileProgressElement.appendChild(progressStatus);
		this.fileProgressElement.appendChild(progressBar);

		this.fileProgressWrapper.appendChild(this.fileProgressElement);

		document.getElementById(targetID).appendChild(this.fileProgressWrapper);
		fadeIn(this.fileProgressWrapper, 0);

	} else {
		this.fileProgressElement = this.fileProgressWrapper.firstChild;
		this.fileProgressElement.childNodes[1].firstChild.nodeValue = file.name;
	}

	this.height = this.fileProgressWrapper.offsetHeight;

}
FileProgress.prototype.setProgress = function (percentage) {
	this.fileProgressElement.className = "progressContainer green";
	this.fileProgressElement.childNodes[3].className = "progressBarInProgress";
	this.fileProgressElement.childNodes[3].style.width = percentage + "%";
};
FileProgress.prototype.setComplete = function () {
	this.fileProgressElement.className = "progressContainer blue";
	this.fileProgressElement.childNodes[3].className = "progressBarComplete";
	this.fileProgressElement.childNodes[3].style.width = "";

};
FileProgress.prototype.setError = function () {
	this.fileProgressElement.className = "progressContainer red";
	this.fileProgressElement.childNodes[3].className = "progressBarError";
	this.fileProgressElement.childNodes[3].style.width = "";

};
FileProgress.prototype.setCancelled = function () {
	this.fileProgressElement.className = "progressContainer";
	this.fileProgressElement.childNodes[3].className = "progressBarError";
	this.fileProgressElement.childNodes[3].style.width = "";

};
FileProgress.prototype.setStatus = function (status) {
	this.fileProgressElement.childNodes[2].innerHTML = status;
};

FileProgress.prototype.toggleCancel = function (show, swfuploadInstance) {
	this.fileProgressElement.childNodes[0].style.visibility = show ? "visible" : "hidden";
	if (swfuploadInstance) {
		var fileID = this.fileProgressID;
		this.fileProgressElement.childNodes[0].onclick = function () {
			swfuploadInstance.cancelUpload(fileID);
			return false;
		};
	}
};
