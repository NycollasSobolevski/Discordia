import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { HomePageComponent } from './home-page/home-page.component';
import { LoginPageComponent } from './login-page/login-page.component';
import { FeedPageComponent } from './feed-page/feed-page.component';
import { HttpClientModule } from '@angular/common/http';
import { AllForumsPageComponent } from './all-forums-page/all-forums-page.component';
import { ForumPageComponent } from './forum-page/forum-page.component';
import { NotFoundPageComponent } from './not-found-page/not-found-page.component';


const routes: Routes = [
  {path: "", title:"Discordia - Home", component: HomePageComponent},
  {path: "login-page", title:"Discordia - Login", component: LoginPageComponent},
  {path: "feed", component : FeedPageComponent},
  {path: "forums", title:"Discordia - Forums", component : AllForumsPageComponent},
  {path: "forum/:forum", title:"Discordia - :forum", component : ForumPageComponent},
  {path: "**", title:"Discordia - 404", component: NotFoundPageComponent }
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes),
    HttpClientModule
  ],
  
  exports: [RouterModule]
})
export class AppRoutingModule { }
