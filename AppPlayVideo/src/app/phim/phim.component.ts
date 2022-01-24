import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-phim',
  templateUrl: './phim.component.html',
  styleUrls: ['./phim.component.css'],
})
export class PhimComponent implements OnInit {
  breakpoint!: number;
  constructor() {}

  ngOnInit(): void {
    this.setBreakPoint(window.innerWidth);
  }

  private setBreakPoint(width: number) {
    if (width <= 480) {
      this.breakpoint = 1;
    } else if (480 < width && width <= 767) {
      this.breakpoint = 3;
    } else if (767 < width && width <= 1024) {
      this.breakpoint = 4;
    } else {
      this.breakpoint = 6;
    }
  }

  onResize(event: any) {
    this.setBreakPoint(event.target.innerWidth);
  }
}
