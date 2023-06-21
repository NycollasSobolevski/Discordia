import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { HomePageComponent } from './home-page/home-page.component';
import { LoginPageComponent } from './login-page/login-page.component';
import { FeedPageComponent } from './feed-page/feed-page.component';

const routes: Routes = [
  {path: "", title:"Discordia - Home", component: HomePageComponent},
  {path: "login-page", title:"Discordia - Login", component: LoginPageComponent},
  {path: "feed", component : FeedPageComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
