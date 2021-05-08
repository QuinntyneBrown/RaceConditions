import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Observable, of } from 'rxjs';
import { map, startWith, switchMap } from 'rxjs/operators';
import { Player } from '../player';
import { PlayerService } from '../player.service';

@Component({
  selector: 'app-players',
  templateUrl: './players.component.html',
  styleUrls: ['./players.component.scss']
})
export class PlayersComponent {
  public readonly players$: Observable<Player[]> = this._playerService.get();    
  public readonly playerSelectControl: FormControl = new FormControl();  

  constructor(
    private readonly _playerService: PlayerService
  ) {  }

  public vm$ = this.playerSelectControl.valueChanges
  .pipe(
    startWith(null),
    switchMap(playerId => playerId ? this._playerService.getById({ playerId }) : of(null)),    
    map((player: Player | null) => new FormGroup({
      name: new FormControl(player?.name),
      description: new FormControl(player?.description)
    })));
}