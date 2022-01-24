import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatSidenavModule } from '@angular/material/sidenav';
import { PhimComponent } from './phim/phim.component';
import { MatCardModule } from '@angular/material/card';
import { MatGridListModule } from '@angular/material/grid-list';
import { HttpClientModule } from '@angular/common/http';
import { VjsPlayerComponent } from './vjs-player/vjs-player.component';

@NgModule({
  declarations: [AppComponent, PhimComponent, VjsPlayerComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    MatToolbarModule,
    MatIconModule,
    MatButtonModule,
    MatSidenavModule,
    MatCardModule,
    MatGridListModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
