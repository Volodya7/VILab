import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { AuthService } from 'app/services/auth.service';
import { Credentials } from 'app/models/credentials';

@Component({
  selector: 'app-root',
  templateUrl: './login.html'
})
export class LoginComponent implements OnInit {
  constructor(private authService: AuthService) {
    this.authService = authService;
  }

  model = new Credentials();

  ngOnInit() {

  }

  login() {
    this.authService.login(this.model.username, this.model.password).then((data) => {
      console.log("component : ");
      console.log(data);
    });

  }
}
