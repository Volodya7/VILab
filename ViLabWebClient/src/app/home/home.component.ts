import { Component, OnInit, } from '@angular/core';

@Component({
  selector: 'home-app',
  templateUrl: './home.component.html'
})

export class HomeComponent {

  sideMenuWidth: string;

  openNav() {
    this.sideMenuWidth = "500px";
  }

  closeNav() {
    this.sideMenuWidth = "0px";
  }
}
