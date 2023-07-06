import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-feed-page',
  templateUrl: './feed-page.component.html',
  styleUrls: ['./feed-page.component.css']
})
export class FeedPageComponent {
  session = sessionStorage.getItem("jwt") ?? "";


  constructor ( private router : Router ) {  }

  ngOnInit( ) {
    if (this.session == "") {
      this.router.navigate(['login-page'])
    }
  }

}
