import { Component } from '@angular/core';
import { ForumService } from '../services/forum.service';
import { Jwt } from '../services/person';
import { HttpErrorResponse } from '@angular/common/http';
import { Forum } from '../services/Model';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent {
  constructor(private service: ForumService) {  }

  jwt : Jwt = {
    value : sessionStorage.getItem('jwt') ?? ""
  }

  protected forumsListFollowed : Forum[] = [];

  ngOnInit(): void {
    this.getForumsFollowed()    ;
    console.log(this.forumsListFollowed);
    
  }

  getForumsFollowed (){
    return this.service
      .GetUserForums(this.jwt)
      
  }
}
