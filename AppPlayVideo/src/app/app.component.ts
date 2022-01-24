import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Phim } from './_model';
import { FileService } from './_service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  title = 'AppPlayVideo';
  showSlideNav = true;
  showFiller = false;
  phims: Phim[] = [];
  private apiURL = environment.apiURL;
  constructor(private _fileService: FileService) {}

  ngOnInit(): void {
    this._fileService.gets().subscribe((results) => {
      this.phims = [];
      for (let i = 0; i < results.length; i++) {
        this.phims.push(
          new Phim({
            URL: `${this.apiURL}/filemanager/download?pathFile=${results[i]}`,
            TENPHIM: results[i],
            URLSUBTITLE: `${this.apiURL}/filemanager/download?pathFile=${results[i]}.vtt`,
          })
        );
      }
    });
  }
}
