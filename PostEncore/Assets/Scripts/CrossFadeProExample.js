var camera0 : Camera;
var camera1 : Camera;
var camera2: Camera;
var fadeTime = 2.0;
private var inProgress = false;
private var swap = false;

function Update () {
	/*if (Input.GetKeyDown("space")) {
		DoFade();
	}*/
}


function DoFade () {
	if (inProgress) return;
	inProgress = true;
	
	swap = !swap;
	yield ScreenWipe.use.CrossFadePro (camera0,camera1, fadeTime);
	inProgress = false;
}

function DoExit()
{
    if (inProgress) return;
    inProgress = true;
	
    swap = !swap;
    yield ScreenWipe.use.CrossFadePro (camera0,camera2, fadeTime);
    inProgress = false;

}

