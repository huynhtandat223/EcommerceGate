import { SystemsModule } from './systems.module';

describe('SystemsModule', () => {
  let systemsModule: SystemsModule;

  beforeEach(() => {
    systemsModule = new SystemsModule();
  });

  it('should create an instance', () => {
    expect(systemsModule).toBeTruthy();
  });
});
