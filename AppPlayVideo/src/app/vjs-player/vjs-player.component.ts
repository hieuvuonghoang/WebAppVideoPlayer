import {
  Component,
  ElementRef,
  Input,
  OnInit,
  ViewChild,
  ViewEncapsulation,
} from '@angular/core';
import videojs from 'video.js';

@Component({
  selector: 'app-vjs-player',
  templateUrl: './vjs-player.component.html',
  styleUrls: ['./vjs-player.component.css'],
  encapsulation: ViewEncapsulation.None,
})
export class VjsPlayerComponent implements OnInit {
  @ViewChild('target', { static: true }) target!: ElementRef;
  // see options: https://github.com/videojs/video.js/blob/maintutorial-options.html
  @Input() options!: {
    fluid: boolean;
    aspectRatio: string;
    autoplay: boolean;
    sources: {
      src: string;
      type: string;
    }[];
    width: number;
    height: number;
    tracks: {
      kind: TextTrackKind;
      mode: TextTrackMode;
      srclang: string;
      src: string;
      default: boolean;
      label: string;
    }[];
  };
  player!: videojs.Player;

  constructor(private elementRef: ElementRef) {}

  ngOnInit() {
    // instantiate Video.js
    this.player = videojs(this.target.nativeElement, this.options, () => {
      console.log('onPlayerReady', this);
    });
    this.player.addTextTrack();
  }

  ngOnDestroy() {
    // destroy player
    if (this.player) {
      this.player.dispose();
    }
  }
}
