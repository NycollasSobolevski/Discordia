import { Component,NgModule } from '@angular/core';
import { ForumToBack } from '../services/Forum'
import { Jwt } from '../services/person';
import { ForumService } from '../services/forum.service';
import { HttpErrorResponse } from '@angular/common/http';


@Component({
  selector: 'app-new-Forum',
  templateUrl: './new-forum.component.html',
  styleUrls: ['./new-forum.component.css']
})
export class NewForumComponent {
  protected titleCount = 0;
  protected textCount = 0;
  protected title = '';
  protected text = '';
  protected viewContainer = false;


  protected forum: ForumToBack = {
    CreatorIdJwt: "",
    Title: "",
    Description: ''
  };

  constructor(private service: ForumService) {  }

  protected updateText(newValue : string){
    this.textCount = newValue.length ;
  }
  protected updateTitle(newValue : string) {
  this.titleCount = newValue.length ;
  }
  protected view(){
    this.viewContainer = !this.viewContainer;
  } 

  checkTitle(){
    return this.titleCount > 5
  }

  createForum(){
    if(!this.checkTitle())
      return

    this.forum.CreatorIdJwt = sessionStorage.getItem('jwt') ?? ""
    this.forum.Description = this.text
    this.forum.Title = this.title

    this.service.CreateForum(this.forum)
      .subscribe({
        next: (res) => {
          location.reload()
        },
        error: (error : HttpErrorResponse) => {
          switch (error.status) {
            case 401:
              console.log(console.error());
              break;
          
            default:
              console.log(error);
              
              break;
          }
        }
    })
  }
}
