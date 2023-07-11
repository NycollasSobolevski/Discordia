import { Component } from '@angular/core';
import { Forum } from '../services/Model';
import { ForumService } from '../services/forum.service';
import { Jwt } from '../services/person';
import { Router } from '@angular/router';

@Component({
  selector: 'app-all-forums-page',
  templateUrl: './all-forums-page.component.html',
  styleUrls: ['./all-forums-page.component.css']
})
export class AllForumsPageComponent {
  protected allForums : Forum[] = []
  protected newListForums : Forum[] = []
  protected forumsListFollowed: Forum[] = [];

  search = ''

  myUser =
  {
    forumListId : ['titanic', 'cleverson']
  }

  jwt : Jwt = {
    value : sessionStorage.getItem('jwt') ?? ""
  };


  //TODOOO: Fazer search box
  // searchChanged(string : string){
  //   console.log(this.allForums);
  //   this.search = string;
  //   this.newListForums = this.allForums.filter(x => x.Title );
  //   console.log(this.newListForums);
  // }

  constructor( private service : ForumService, private router : Router ){  }

  ngOnInit() : void  {
    if (this.jwt.value == "") {
      this.router.navigate(['login-page'])
      return
    }
    this.getForums();
    this.getForumsFollowed();
  }





  getForums(){
    this.service.GetAllForums()
      .subscribe( (item : any) => {
        let list : Forum[] = []
        item.forEach((element : any )=> {
          list.push(element);
        });
        this.allForums = list;  
    })
  }
  getForumsFollowed (){
    return this.service
      .GetUserForums(this.jwt)
      .subscribe( item => {
        let list: Forum[] = []
        item.forEach(forums => {
          list.push(forums)
          this.forumsListFollowed = list;
        })
      })
  }
}
