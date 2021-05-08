import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { BehaviorSubject, forkJoin, of, Subject } from 'rxjs';
import { map, startWith, switchMap } from 'rxjs/operators';
import { Player } from '../player';
import { PlayerService } from '../player.service';

@Component({
  selector: 'app-players',
  templateUrl: './players.component.html',
  styleUrls: ['./players.component.scss']
})
export class PlayersComponent {
  private readonly _destroyed: Subject<void> = new Subject();
  public readonly players$: BehaviorSubject<Player[]> = new BehaviorSubject([]);    
  public readonly playerSelectControl: FormControl = new FormControl();  
  public readonly playerForm: FormGroup = new FormGroup({
    name: new FormControl("", []),
    description: new FormControl("",[])
  });

  constructor(
    private readonly _playerService: PlayerService
  ) {  }

  public vm$ = this.playerSelectControl.valueChanges
  .pipe(
    startWith(0),
    switchMap(playerId => forkJoin([
      playerId ? this._playerService.getById({ playerId }): of({}),
      !playerId ? this._playerService.get() : of(null)
    ])),    
    map(([player,players]) => {
      this.playerForm.patchValue(player);
      this.players$.next(players || this.players$.value);
      return true;
    }));
}