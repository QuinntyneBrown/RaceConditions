import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { PlayersModule } from './players/players.module';
import { baseUrl } from '@core/constants';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    PlayersModule,
    HttpClientModule,
    BrowserModule,
    BrowserAnimationsModule
  ],
  providers: [
    { useValue: "https://localhost:5001/", provide: baseUrl}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
