import { Component, OnInit } from '@angular/core';
import { NavbarData } from './nav-data';

@Component({
  selector: 'app-sidenav',
  templateUrl: './sidenav.component.html',
  styleUrls: ['./sidenav.component.css']
})
export class SidenavComponent implements OnInit {

  collapsed = false;
  navData = NavbarData;

  constructor() { }

  ngOnInit(): void {
  }

}
