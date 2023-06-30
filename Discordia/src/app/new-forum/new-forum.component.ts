import { Component,NgModule } from '@angular/core';
import { Forum } from '../services/Forum'
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

  private creator = localStorage.getItem('jwt')

  protected forum: Forum = {
    CreatorId: "",
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

    this.forum.CreatorId = sessionStorage.getItem('jwt') ?? ""
    this.forum.Description = this.text
    this.forum.Title = this.title

    this.service.CreateForum(this.forum)
      .subscribe({
        next: () => {
          location.reload()
        },
        error: (error : HttpErrorResponse) => {
          switch (error.status) {
            case 401:
              console.log(console.error());
              break;
          
            default:
              break;
          }
        }
    })
  }
}
