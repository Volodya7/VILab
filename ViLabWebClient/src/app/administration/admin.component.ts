import { Component, OnInit } from '@angular/core';
import { AuthService } from 'app/services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './admin.html'
})
export class AdminComponent implements OnInit{
  constructor(private authService: AuthService) { }

  ngOnInit() {

  }

  logout() {
    this.authService.logout();
  }
}
