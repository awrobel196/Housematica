
var canvas = document.getElementById("renderCanvas");

var engine = null;
var scene = null;

var sceneToRender = null;
var createDefaultEngine = function() { return new BABYLON.Engine(canvas, true, 
    { preserveDrawingBuffer: true, stencil: true }); };



function delayCreateScene() {

var scene1 = new BABYLON.Scene(engine);

scenes = [];
scenes.push(scene1);

var currentScene = scene1;

var camera1 = new BABYLON.ArcRotateCamera("camera1",  0, 0, 0, new BABYLON.Vector3(0, 0, -0), scene1);
camera1.wheelprecision = 24000;
    BABYLON.SceneLoader.ShowLoadingScreen = false;
    BABYLON.SceneLoader.Append("https://cdn.housematica.pl/a1315678-589d-42d8-35d5-08d8ede1a239/A08/ApartmentVariant1/", "untitled.babylon", scene1, function (scene1) {
scene1.createDefaultCameraOrLight(true, true, true);
scene1.clearColor = new BABYLON.Color3(255,255,255);

scene1.activeCamera.lowerBetaLimit = 1;

scene1.activeCamera.upperBetaLimit = 1.5;


var light = new BABYLON.DirectionalLight("light1", new BABYLON.Vector3(-2, -6, -2), scene1);
    light.position = new BABYLON.Vector3(20, 60, 20);
    light.shadowMinZ = 30;
    light.shadowMaxZ = 180;
    light.intensity = 1;

    var generator = new BABYLON.ShadowGenerator(512, light);
    generator.useContactHardeningShadow = true;
    generator.bias = 0.01;
    generator.normalBias= 0.05;
    generator.contactHardeningLightSizeUVRatio = 0.08;

    for (var i = 0; i < scene1.meshes.length; i++) {
        generator.addShadowCaster(scene1.meshes[i]);    
        scene1.meshes[i].receiveShadows = true;
        if (scene1.meshes[i].material && scene1.meshes[i].material.bumpTexture) {
            scene1.meshes[i].material.bumpTexture.level = 2;
        }
    }

camera1 = scene1.activeCamera;
});




// Append glTF model to scene.





//Switch scenes every 3 sec




//runRenderLoop inside a setTimeout is neccesary in the Playground
//to stop the PG's runRenderLoop.

return scene1;

}


var engine;
try {
engine = createDefaultEngine();
} catch(e) {
console.log("the available createEngine function failed. Creating the default engine instead");
engine = createDefaultEngine();
}
if (!engine) throw 'engine should not be null.';
scene = delayCreateScene();;
sceneToRender = scene

engine.runRenderLoop(function () {
    if (sceneToRender) {
        sceneToRender.render();
    }
});

// Resize
window.addEventListener("resize", function () {
    engine.resize();
});

