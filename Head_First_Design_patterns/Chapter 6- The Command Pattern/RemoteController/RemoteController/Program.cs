// See https://aka.ms/new-console-template for more information

using RemoteController;
using RemoteController.Commands;
using RemoteController.Models;

var remoteControl = new RemoteControl();

var livingRoomLight = new Light(RoomsEnum.LivingRoom);
var kitchenLight = new Light(RoomsEnum.Kitchen);
var livingRoomCeilingFan = new CeilingFan(RoomsEnum.LivingRoom);
var garageDoor = new Door(RoomsEnum.Garage);
var livingRoomStereo = new Stereo(RoomsEnum.LivingRoom);

var livingRoomLightOn = new LightOnCommand(livingRoomLight);
var livingRoomLightOff = new LightOffCommand(livingRoomLight);

var kitchenLightOn = new LightOnCommand(kitchenLight);
var kitchenLightOff = new LightOffCommand(kitchenLight);

var ceilingFanOn = new CeilingFanOnCommand(livingRoomCeilingFan);
var ceilingFanOff = new CeilingFanOffCommand(livingRoomCeilingFan);

var garageDoorUpCommand = new DoorUpCommand(garageDoor);
var garageDoorDownCommand = new DoorDownCommand(garageDoor);

var stereoOnWithCD = new StereoOnWithCDCommand(livingRoomStereo);
var stereoOffWithCD = new StereoOffWithCDCommand(livingRoomStereo);

remoteControl.setCommand(0, livingRoomLightOn, livingRoomLightOff);
remoteControl.setCommand(1, kitchenLightOn, kitchenLightOff);
remoteControl.setCommand(2, ceilingFanOn, ceilingFanOff);
remoteControl.setCommand(3, stereoOnWithCD, stereoOffWithCD);
remoteControl.setCommand(4, garageDoorUpCommand, garageDoorDownCommand);

Console.WriteLine(remoteControl);

Console.WriteLine("------ Commands ------");
remoteControl.pressOnButton(0);
remoteControl.pressOffButton(0);
remoteControl.pressOnButton(1);
remoteControl.pressOffButton(1);
remoteControl.pressOnButton(2);
remoteControl.pressOffButton(2);
remoteControl.pressOnButton(3);
remoteControl.pressOffButton(3);
remoteControl.pressOnButton(4);
remoteControl.pressOffButton(4);